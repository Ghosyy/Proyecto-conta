using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entidades;

namespace BLL
{
    public class PartidaBLL
    {
        private PartidaDAL partidaDal = new PartidaDAL();

        public bool RegistrarPartida(Partida partida)
        {
            // AQUÍ ESTÁ EL CAMBIO: Evaluamos "Descripcion" en lugar de "Concepto"
            if (string.IsNullOrWhiteSpace(partida.Descripcion))
                throw new ArgumentException("La descripción de la partida es obligatoria.");

            if (partida.Detalles.Count < 2)
                throw new ArgumentException("La partida debe tener al menos dos movimientos (un cargo y un abono).");

            decimal totalDebe = partida.Detalles.Sum(d => d.Debe);
            decimal totalHaber = partida.Detalles.Sum(d => d.Haber);

            if (totalDebe != totalHaber)
                throw new ArgumentException($"La partida no cuadra. Diferencia: Q{Math.Abs(totalDebe - totalHaber)}");

            if (totalDebe == 0 && totalHaber == 0)
                throw new ArgumentException("La partida no puede estar en cero.");

            return partidaDal.InsertarPartida(partida);
        }
        public bool EjecutarRegularizacionIVA()
        {
            // 1. Obtenemos los saldos de tus dos cuentas de IVA
            // Usamos los códigos exactos que tienes en tu base de datos
            partidaDal.ObtenerSaldosCuenta("1.1.04", out decimal debeCobrar, out decimal haberCobrar);
            partidaDal.ObtenerSaldosCuenta("2.1.02", out decimal debePagar, out decimal haberPagar);

            // 2. Calculamos el saldo real de cada cuenta
            // IVA por Cobrar es Activo (Debe - Haber)
            decimal saldoIvaCobrar = debeCobrar - haberCobrar;

            // IVA por Pagar es Pasivo (Haber - Debe)
            decimal saldoIvaPagar = haberPagar - debePagar;

            // 3. Validaciones de seguridad
            if (saldoIvaCobrar <= 0 && saldoIvaPagar <= 0)
                throw new Exception("No hay saldos de IVA suficientes para regularizar este mes.");

            // 4. La regla contable: Se toma el saldo MENOR de los dos para hacer el cruce
            decimal montoRegularizar = Math.Min(saldoIvaCobrar, saldoIvaPagar);

            if (montoRegularizar <= 0)
                throw new Exception("Uno de los saldos de IVA está en cero. No es posible realizar el cruce.");

            // 5. Armamos la partida automáticamente
            Partida partidaReg = new Partida
            {
                NumeroPartida = "99", // CAMBIAMOS "REG-IVA" POR UN NÚMERO
                FechaTransaccion = DateTime.Now,
                TipoPartida = "Diario",
                Descripcion = "Regularización automática del IVA del mes"
            };

            // Para liquidar el impuesto, las cuentas se invierten:
            // El IVA por Pagar (Pasivo) se carga en el Debe para disminuir
            partidaReg.Detalles.Add(new DetallePartida { CodigoCuenta = "2.1.02", NombreCuenta = "IVA por Pagar", Debe = montoRegularizar, Haber = 0 });

            // El IVA por Cobrar (Activo) se abona en el Haber para disminuir
            partidaReg.Detalles.Add(new DetallePartida { CodigoCuenta = "1.1.04", NombreCuenta = "IVA por Cobrar", Debe = 0, Haber = montoRegularizar });

            // 6. Enviamos esta partida a guardar a la base de datos usando tu método que ya funciona
            return RegistrarPartida(partidaReg);
        }

        public DataTable ObtenerLibroDiario()
        {
            return partidaDal.ObtenerLibroDiario();
        }

        public DataTable ObtenerLibroMayor()
        {
            return partidaDal.ObtenerLibroMayor();
        }

        public DataTable ObtenerEstadoResultados()
        {
            return partidaDal.ObtenerEstadoResultados();
        }

        public DataTable ObtenerSaldosBalance()
        {
            return partidaDal.ObtenerSaldosBalance();
        }

        public bool EjecutarPartidasDeCierre()
        {
            Partida partidaCierre = new Partida
            {
                NumeroPartida = "100",
                FechaTransaccion = DateTime.Now,
                TipoPartida = "Cierre",
                Descripcion = "Cierre de cuentas de resultados y utilidad del ejercicio"
            };

            decimal saldoIngresosTotal = 0;

            // 1. Cierre de Ingresos (Revisamos tanto la 4 como la 4.1.01 por tus datos de prueba)
            string[] codigosIngresos = { "4", "4.1.01" };
            foreach (string cod in codigosIngresos)
            {
                partidaDal.ObtenerSaldosCuenta(cod, out decimal dIng, out decimal hIng);
                decimal saldo = hIng - dIng;
                if (saldo > 0)
                {
                    partidaCierre.Detalles.Add(new DetallePartida { CodigoCuenta = cod, NombreCuenta = "Cierre Ingresos", Debe = saldo, Haber = 0 });
                    saldoIngresosTotal += saldo;
                }
            }

            // 2. Cierre de Gastos y Costos (Agregamos la 5 por si acaso)
            string[] codigosGastos = { "6.1.01", "6.1.02", "6.1.03", "5", "5.1.01" };
            decimal totalGastos = 0;
            foreach (string cod in codigosGastos)
            {
                partidaDal.ObtenerSaldosCuenta(cod, out decimal dGas, out decimal hGas);
                decimal saldoGasto = dGas - hGas;
                if (saldoGasto > 0)
                {
                    partidaCierre.Detalles.Add(new DetallePartida { CodigoCuenta = cod, NombreCuenta = "Cierre Gastos", Debe = 0, Haber = saldoGasto });
                    totalGastos += saldoGasto;
                }
            }

            // 3. Validación anti-errores: Si ya está todo cerrado, detenemos el proceso suavemente
            if (saldoIngresosTotal == 0 && totalGastos == 0)
            {
                throw new Exception("Ya no hay saldos pendientes en las cuentas de ingresos y gastos. El mes ya está cerrado.");
            }

            // 4. Traslado a Utilidad o Pérdida
            decimal utilidad = saldoIngresosTotal - totalGastos;
            if (utilidad > 0)
                partidaCierre.Detalles.Add(new DetallePartida { CodigoCuenta = "3.1.02", NombreCuenta = "Utilidad del Ejercicio", Debe = 0, Haber = utilidad });
            else if (utilidad < 0)
                partidaCierre.Detalles.Add(new DetallePartida { CodigoCuenta = "3.1.02", NombreCuenta = "Pérdida del Ejercicio", Debe = Math.Abs(utilidad), Haber = 0 });

            return RegistrarPartida(partidaCierre);
        }

        public bool ActualizarMontoDetalle(string numeroPartida, string codigoCuenta, decimal nuevoDebe, decimal nuevoHaber)
        {
            return partidaDal.ActualizarMontoDetalle(numeroPartida, codigoCuenta, nuevoDebe, nuevoHaber);
        }
    }
}
