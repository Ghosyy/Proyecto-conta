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
    public partial class FormLibroDiario : Form
    {
        public FormLibroDiario()
        {
            InitializeComponent();
            

            // ── TEMA VISUAL ──────────────────────────────────────────────────

            ThemeManager.AplicarTema(this);
            this.Text = "Libro Diario";

            // Encabezado de sección
            ThemeManager.AgregarEncabezadoSeccion(this, "LIBRO DIARIO — Consulta y Edición",
                dgvLibroDiario.Left, 8);

            // El grid empieza con un poco más de espacio para el encabezado
            dgvLibroDiario.Top = 32;

            // Sobreescribir botones con sus roles correctos
            ThemeManager.EstilizarBoton(btnActualizar, ThemeManager.TipoBoton.Secundario);
            ThemeManager.EstilizarBoton(btnEditar, ThemeManager.TipoBoton.Primario);

            // Panel blanco para la zona de edición inferior
            Panel pnlEdicion = new Panel
            {
                BackColor = ThemeManager.ColorSuperficie,
                Location = new Point(0, dgvLibroDiario.Bottom + 4),
                Size = new Size(this.ClientSize.Width,
                                     this.ClientSize.Height - dgvLibroDiario.Bottom - 4)
            };
            this.Controls.Add(pnlEdicion);
            pnlEdicion.SendToBack();
        }

        private void FormLibroDiario_Load(object sender, EventArgs e)
        {
            try
            {
                BLL.PartidaBLL bll = new BLL.PartidaBLL();
                dgvLibroDiario.DataSource = bll.ObtenerLibroDiario();

                // Le damos formato de moneda (Quetzales) a las columnas de Debe y Haber
                dgvLibroDiario.Columns["Debe"].DefaultCellStyle.Format = "C2";
                dgvLibroDiario.Columns["Haber"].DefaultCellStyle.Format = "C2";

                // Hacemos que las columnas se estiren para rellenar el espacio
                dgvLibroDiario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el Libro Diario: " + ex.Message);
            }
        }

        private void dgvLibroDiario_Click(object sender, EventArgs e)
        {

        }

        private void dgvLibroDiario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvLibroDiario.Rows[e.RowIndex];

                // Llenamos los textboxes
                txtNumPartida.Text = fila.Cells["No. Partida"].Value.ToString();
                txtCodigo.Text = fila.Cells["Código"].Value.ToString();
                txtDebe.Text = fila.Cells["Debe"].Value.ToString().Replace("Q", "").Trim();
                txtHaber.Text = fila.Cells["Haber"].Value.ToString().Replace("Q", "").Trim();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Validaciones básicas
                if (string.IsNullOrEmpty(txtNumPartida.Text)) throw new Exception("Seleccione una partida de la tabla.");

                if (!decimal.TryParse(txtDebe.Text, out decimal nuevoDebe)) throw new Exception("Debe inválido.");
                if (!decimal.TryParse(txtHaber.Text, out decimal nuevoHaber)) throw new Exception("Haber inválido.");
                
                // 2. Ejecutar la actualización en DAL
                BLL.PartidaBLL bll = new BLL.PartidaBLL();
                bool exito = bll.ActualizarMontoDetalle(txtNumPartida.Text, txtCodigo.Text, nuevoDebe, nuevoHaber);

                if (exito)
                {
                    MessageBox.Show("Partida actualizada. ¡No olvide ejecutar el Cierre Mensual para reflejar los cambios!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 3. Recargar el libro diario
                    FormLibroDiario_Load(null, null);

                    // Limpiar
                    txtNumPartida.Clear(); txtCodigo.Clear(); txtDebe.Clear(); txtHaber.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
