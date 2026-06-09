using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PanaderiaIxtapan_UII;

namespace PanaderiaIxtapan_UII
{
    public partial class FormLibroMayor : Form
    {
        public FormLibroMayor()
        {
            InitializeComponent();
            // ── TEMA VISUAL ──────────────────────────────────────────────────
            ThemeManager.AplicarTema(this);
            this.Text = "Libro Mayor";
            ThemeManager.AgregarEncabezadoSeccion(this, "LIBRO MAYOR — Saldos por Cuenta",
                dgvLibroMayor.Left, 8);
            dgvLibroMayor.Top = 32;
        }

        private void FormLibroMayor_Load(object sender, EventArgs e)
        {
            try
            {
                BLL.PartidaBLL bll = new BLL.PartidaBLL();
                dgvLibroMayor.DataSource = bll.ObtenerLibroMayor();

                // Le damos formato Quetzales a las 3 columnas de dinero
                dgvLibroMayor.Columns["Total Debe"].DefaultCellStyle.Format = "C2";
                dgvLibroMayor.Columns["Total Haber"].DefaultCellStyle.Format = "C2";
                dgvLibroMayor.Columns["Saldo Matemático"].DefaultCellStyle.Format = "C2";

                dgvLibroMayor.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el Libro Mayor: " + ex.Message);
            }
        }
    }
}

