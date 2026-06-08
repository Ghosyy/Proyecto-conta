using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using BLL;
using PanaderiaIxtapan_UI;

namespace PanaderiaIxtapan_UII
{
    public partial class FormPartidas : Form
    {
        private BindingList<DetallePartida> listaDetalles = new BindingList<DetallePartida>();

        public FormPartidas()
        {
            InitializeComponent();
            ThemeManager.AplicarEstiloYCentrar(this, "Registrar Partidas - Panadería Ixtapan");
        }

        private void FormPartidas_Load(object sender, EventArgs e)
        {
            // Vinculamos la lista al DataGridView
            dgvDetallePartida.DataSource = listaDetalles;
            dgvDetallePartida.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Cargamos el combobox con las cuentas de la BD
            CargarCuentasEnCombo();

            // Valores por defecto
            txtDebe.Text = "0.00";
            txtHaber.Text = "0.00";

        }

        private void CargarCuentasEnCombo()
        {
            CuentaBLL cuentaBLL = new CuentaBLL();
            List<Cuenta> catalogo = cuentaBLL.ListarCatalogo();

            cmbCuentas.DataSource = catalogo;
            cmbCuentas.DisplayMember = "NombreCuenta"; // Lo que ve el usuario
            cmbCuentas.ValueMember = "CodigoCuenta";   // El código que se guarda
        }

        private void btnAgregarFila_Click(object sender, EventArgs e)
        {
            try
            {
                decimal debe = Convert.ToDecimal(txtDebe.Text);
                decimal haber = Convert.ToDecimal(txtHaber.Text);

                if (debe == 0 && haber == 0)
                {
                    MessageBox.Show("Debe ingresar un valor en Debe o en Haber.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Cuenta cuentaSeleccionada = (Cuenta)cmbCuentas.SelectedItem;

                DetallePartida nuevoDetalle = new DetallePartida
                {
                    CodigoCuenta = cuentaSeleccionada.CodigoCuenta,
                    NombreCuenta = cuentaSeleccionada.NombreCuenta,
                    Debe = debe,
                    Haber = haber
                };

                listaDetalles.Add(nuevoDetalle);
                ActualizarTotales();

                // Limpiar cajas para el siguiente movimiento
                txtDebe.Text = "0.00";
                txtHaber.Text = "0.00";
                cmbCuentas.Focus();
            }
            catch (Exception)
            {
                MessageBox.Show("Por favor ingrese cantidades numéricas válidas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarTotales()
        {
            decimal totalDebe = listaDetalles.Sum(d => d.Debe);
            decimal totalHaber = listaDetalles.Sum(d => d.Haber);

            lblTotalDebe.Text = $"Total Debe: {totalDebe:C}";
            lblTotalHaber.Text = $"Total Haber: {totalHaber:C}";
        }

        private void btnGuardarPartida_Click(object sender, EventArgs e)
        {
            try
            {
                Partida nuevaPartida = new Partida
                {
                    NumeroPartida = txtNumeroPartida.Text, // El nuevo campo
                    FechaTransaccion = dtpFecha.Value,     // Ajustado al nuevo nombre
                    Descripcion = txtConcepto.Text,        // Ajustado al nuevo nombre
                    TipoPartida = cmbTipoPartida.Text,     // El nuevo campo
                    Detalles = listaDetalles.ToList()
                };

                PartidaBLL bll = new PartidaBLL();

                if (bll.RegistrarPartida(nuevaPartida))
                {
                    MessageBox.Show("¡Partida registrada exitosamente en la base de datos!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    listaDetalles.Clear();
                    txtConcepto.Clear();
                    txtNumeroPartida.Clear();
                    ActualizarTotales();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGenerarIVA_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Obtenemos el total de la factura
                decimal total = Convert.ToDecimal(txtTotalFactura.Text);

                if (total <= 0)
                {
                    MessageBox.Show("El monto de la factura debe ser mayor a cero.");
                    return;
                }

                // 2. Cálculos según la ley de Guatemala (12%)
                decimal baseImponible = Math.Round(total / 1.12m, 2);
                decimal iva = Math.Round(total - baseImponible, 2);

                // 3. Verificamos si es Compra o Venta
                string tipoOperacion = cmbTipoFactura.Text;

                if (tipoOperacion.Contains("Compra"))
                {
                    // PARTIDA DE COMPRA
                    listaDetalles.Add(new DetallePartida { CodigoCuenta = "1.1.05", NombreCuenta = "Inventario de Materia Prima", Debe = baseImponible, Haber = 0 });
                    listaDetalles.Add(new DetallePartida { CodigoCuenta = "1.1.04", NombreCuenta = "IVA por Cobrar", Debe = iva, Haber = 0 });
                    listaDetalles.Add(new DetallePartida { CodigoCuenta = "1.1.01", NombreCuenta = "Caja", Debe = 0, Haber = total });
                }
                else if (tipoOperacion.Contains("Venta"))
                {
                    // PARTIDA DE VENTA
                    listaDetalles.Add(new DetallePartida { CodigoCuenta = "1.1.01", NombreCuenta = "Caja", Debe = total, Haber = 0 });
                    listaDetalles.Add(new DetallePartida { CodigoCuenta = "4.1.01", NombreCuenta = "Ventas", Debe = 0, Haber = baseImponible });
                    listaDetalles.Add(new DetallePartida { CodigoCuenta = "2.1.02", NombreCuenta = "IVA por Pagar", Debe = 0, Haber = iva });
                }
                else
                {
                    MessageBox.Show("Seleccione el tipo de operación (Compra o Venta).");
                    return;
                }

                // 4. Actualizamos el DataGridView y limpiamos
                ActualizarTotales();
                txtTotalFactura.Clear();

                MessageBox.Show("¡Desglose generado! Revisa la tabla y presiona 'Guardar partida completa'.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Ingrese un monto numérico válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
    
