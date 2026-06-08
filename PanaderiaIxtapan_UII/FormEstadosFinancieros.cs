using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PanaderiaIxtapan_UI;

namespace PanaderiaIxtapan_UII
{
    public partial class FormEstadosFinancieros : Form
    {
        public FormEstadosFinancieros()
        {
            InitializeComponent();
            ThemeManager.AplicarEstiloYCentrar(this, "Estados Financieros - Panadería Ixtapan");
        }

        private void FormEstadosFinancieros_Load(object sender, EventArgs e)
        {
            ConfigurarColumnasExcel(dgvResultados);
            ConfigurarColumnasExcel(dgvBalance);
            GenerarEstadoResultados();
            GenerarBalanceGeneral();
        }



        // Esta función crea las columnas vacías para simular el Excel
        private void ConfigurarColumnasExcel(DataGridView dgv)
        {
            dgv.Columns.Clear();
            dgv.Columns.Add("Descripcion", "Descripción");
            dgv.Columns.Add("Col1", "Parciales");
            dgv.Columns.Add("Col2", "Subtotales");
            dgv.Columns.Add("Col3", "Totales");

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AllowUserToAddRows = false;
            dgv.RowHeadersVisible = false;
            dgv.ReadOnly = true;
            dgv.BackgroundColor = Color.White;

            // Formato de Quetzales para las columnas numéricas
            dgv.Columns["Col1"].DefaultCellStyle.Format = "C2";
            dgv.Columns["Col2"].DefaultCellStyle.Format = "C2";
            dgv.Columns["Col3"].DefaultCellStyle.Format = "C2";
        }

        private void GenerarEstadoResultados()
        {
            try
            {
                BLL.PartidaBLL bll = new BLL.PartidaBLL();
                DataTable dt = bll.ObtenerEstadoResultados();

                decimal totalVentas = 0;
                decimal totalCostos = 0;
                decimal totalGastos = 0;

                // 1. Extraer los montos de la base de datos
                foreach (DataRow row in dt.Rows)
                {
                    string cod = row["Código"].ToString();
                    decimal monto = Convert.ToDecimal(row["Monto Acumulado"]);

                    if (cod.StartsWith("4")) totalVentas += monto;
                    else if (cod.StartsWith("5")) totalCostos += monto;
                }

                decimal utilidadBruta = totalVentas - totalCostos;

                // 2. DIBUJAR EL REPORTE ESTILO EXCEL (Fila por fila)
                dgvResultados.Rows.Add("INGRESOS DE OPERACIÓN", "", "", "");
                dgvResultados.Rows.Add("Ventas", "", totalVentas, "");

                if (totalCostos > 0)
                {
                    dgvResultados.Rows.Add("(-) Costo de Ventas", "", totalCostos, "");
                }

                // Línea de Utilidad Bruta en la última columna
                dgvResultados.Rows.Add("UTILIDAD BRUTA", "", "", utilidadBruta);
                dgvResultados.Rows.Add("", "", "", ""); // Espacio en blanco

                dgvResultados.Rows.Add("GASTOS DE OPERACIÓN", "", "", "");

                // 3. Imprimir cada gasto en la primera columna y sumarlos
                foreach (DataRow row in dt.Rows)
                {
                    string cod = row["Código"].ToString();
                    if (cod.StartsWith("6")) // Si es un Gasto
                    {
                        decimal montoGasto = Convert.ToDecimal(row["Monto Acumulado"]);
                        string nombreGasto = row["Cuenta"].ToString();
                        dgvResultados.Rows.Add(nombreGasto, montoGasto, "", "");
                        totalGastos += montoGasto;
                    }
                }

                // Subtotal de gastos en la columna de en medio
                dgvResultados.Rows.Add("TOTAL GASTOS DE OPERACIÓN", "", totalGastos, "");
                dgvResultados.Rows.Add("", "", "", ""); // Espacio

                // 4. Calcular y mostrar Utilidad del Ejercicio
                decimal utilidadNeta = utilidadBruta - totalGastos;
                dgvResultados.Rows.Add("RESULTADO DEL EJERCICIO", "", "", utilidadNeta);

                // Pintar de negrita los títulos importantes para que resalte
                PintarNegritas(dgvResultados);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al armar el reporte: " + ex.Message);
            }
        }

        private void GenerarBalanceGeneral()
        {
            try
            {
                BLL.PartidaBLL bll = new BLL.PartidaBLL();
                DataTable dt = bll.ObtenerSaldosBalance();

                decimal totalActivo = 0;
                decimal totalPasivo = 0;
                decimal totalCapital = 0;

                // --- SECCIÓN ACTIVO ---
                dgvBalance.Rows.Add("ACTIVO", "", "", "");
                foreach (DataRow row in dt.Rows)
                {
                    string cod = row["CodigoCuenta"].ToString();
                    if (cod.StartsWith("1"))
                    {
                        decimal saldo = Convert.ToDecimal(row["Saldo"]);
                        dgvBalance.Rows.Add(row["NombreCuenta"].ToString(), saldo, "", "");
                        totalActivo += saldo;
                    }
                }
                dgvBalance.Rows.Add("SUMA DEL ACTIVO", "", "", totalActivo);
                dgvBalance.Rows.Add("", "", "", "");

                // --- SECCIÓN PASIVO ---
                dgvBalance.Rows.Add("PASIVO", "", "", "");
                foreach (DataRow row in dt.Rows)
                {
                    string cod = row["CodigoCuenta"].ToString();
                    if (cod.StartsWith("2"))
                    {
                        decimal saldo = Convert.ToDecimal(row["Saldo"]);
                        dgvBalance.Rows.Add(row["NombreCuenta"].ToString(), saldo, "", "");
                        totalPasivo += saldo;
                    }
                }
                dgvBalance.Rows.Add("SUMA DEL PASIVO", "", totalPasivo, "");
                dgvBalance.Rows.Add("", "", "", "");

                // --- SECCIÓN CAPITAL ---
                dgvBalance.Rows.Add("CAPITAL", "", "", "");
                foreach (DataRow row in dt.Rows)
                {
                    string cod = row["CodigoCuenta"].ToString();
                    if (cod.StartsWith("3"))
                    {
                        decimal saldo = Convert.ToDecimal(row["Saldo"]);
                        dgvBalance.Rows.Add(row["NombreCuenta"].ToString(), saldo, "", "");
                        totalCapital += saldo;
                    }
                }
                dgvBalance.Rows.Add("SUMA DEL CAPITAL", "", totalCapital, "");
                dgvBalance.Rows.Add("", "", "", "");

                // --- CUADRE FINAL ---
                decimal sumaPasivoCapital = totalPasivo + totalCapital;
                dgvBalance.Rows.Add("SUMA PASIVO Y CAPITAL", "", "", sumaPasivoCapital);

                PintarNegritasBalance(dgvBalance);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al armar el balance: " + ex.Message);
            }
        }

        private void PintarNegritasBalance(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                string desc = row.Cells["Descripcion"].Value?.ToString();
                if (desc == "ACTIVO" || desc == "SUMA DEL ACTIVO" ||
                    desc == "PASIVO" || desc == "SUMA DEL PASIVO" ||
                    desc == "CAPITAL" || desc == "SUMA DEL CAPITAL" ||
                    desc == "SUMA PASIVO Y CAPITAL")
                {
                    row.DefaultCellStyle.Font = new Font(dgv.Font, FontStyle.Bold);
                }
            }
        }



        private void PintarNegritas(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                string desc = row.Cells["Descripcion"].Value?.ToString();
                if (desc == "INGRESOS DE OPERACIÓN" || desc == "UTILIDAD BRUTA" ||
                    desc == "GASTOS DE OPERACIÓN" || desc == "RESULTADO DEL EJERCICIO")
                {
                    row.DefaultCellStyle.Font = new Font(dgv.Font, FontStyle.Bold);
                }
            }
        }
    }
}
    
