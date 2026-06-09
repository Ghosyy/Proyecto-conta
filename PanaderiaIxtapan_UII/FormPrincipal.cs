using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Entidades;
using PanaderiaIxtapan_UII;

namespace PanaderiaIxtapan_UII
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
            // ── TEMA VISUAL ──────────────────────────────────────────────────

            // 1. Aplicar tema global a TODOS los controles del formulario
            ThemeManager.AplicarTema(this);
            this.Text = "Sistema Contable — Panadería Ixtapan";

            // 2. SOBREESCRIBIR colores de botones específicos
            //    (la detección automática falla en 'btnEliminarInventari' porque
            //     ese botón en realidad EDITA, no elimina — nombre heredado del diseñador)
            ThemeManager.EstilizarBoton(btnAgregarInventario, ThemeManager.TipoBoton.Exito);
            ThemeManager.EstilizarBoton(btnEliminarInventari, ThemeManager.TipoBoton.Secundario);  // Botón EDITAR
            ThemeManager.EstilizarBoton(btnEliminarInventario, ThemeManager.TipoBoton.Peligro);

            // 3. Encabezados de sección sobre cada DataGridView
            ThemeManager.AgregarEncabezadoSeccion(this, "CATÁLOGO DE CUENTAS",
                dgvCuentas.Left, dgvCuentas.Top - 24);

            ThemeManager.AgregarEncabezadoSeccion(this, "GESTIÓN DE INVENTARIO",
                dgvInventario.Left, dgvInventario.Top - 24);

            // 4. Panel blanco detrás del área de formulario de inventario
            Panel pnlFormInv = new Panel
            {
                BackColor = ThemeManager.ColorSuperficie,
                Location = new Point(0, dgvInventario.Bottom + 4),
                Size = new Size(this.ClientSize.Width, this.ClientSize.Height - dgvInventario.Bottom - 4),
                Padding = new Padding(6)
            };
            this.Controls.Add(pnlFormInv);
            pnlFormInv.SendToBack();

            // 5. Ajustar fuentes de los Labels de campo (etiquetas pequeñas)
            foreach (Control c in this.Controls)
            {
                if (c is Label lbl && c != null)
                {
                    lbl.Font = ThemeManager.FuenteLabel;
                    lbl.ForeColor = ThemeManager.ColorTextoSecundario;
                }
            }
        }

        private void dgvCuentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void CargarCatalogo()
        {
            try
            {
                CuentaBLL bll = new CuentaBLL();

                // Traemos la lista desde la base de datos
                List<Cuenta> catalogo = bll.ListarCatalogo();

                // Llenamos la cuadrícula automáticamente
                dgvCuentas.DataSource = catalogo;

                // Ajustamos el tamaño de las columnas para que se vea ordenado y ocupe todo el espacio
                dgvCuentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el catálogo de cuentas: " + ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarInventario()
        {
            try
            {
                ProductoBLL bll = new ProductoBLL();
                dgvInventario.DataSource = bll.ListarInventario();
                dgvInventario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el inventario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    

    private void FormPrincipal_Load(object sender, EventArgs e)
        {
            CargarCatalogo();
            CargarInventario();
        }

        private void dgvInventario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void registrarNuevaPartidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Instanciamos tu nuevo formulario de partidas
            FormPartidas formPartidas = new FormPartidas();

            // Usamos ShowDialog() en lugar de Show()
            // Esto congela el menú de fondo para que el usuario se enfoque solo en cuadrar la partida
            formPartidas.ShowDialog();

            // Opcional: Si quieres que tus tablas del menú principal se actualicen solitas al cerrar la partida, 
            CargarCatalogo();
            CargarInventario();
        }

        private void regularizaciónDeIVAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Preguntamos al usuario si está seguro, porque esto es un proceso de cierre
                DialogResult dialogo = MessageBox.Show("¿Está seguro que desea ejecutar la regularización de IVA del mes actual?", "Confirmar Cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogo == DialogResult.Yes)
                {
                    // Llamamos a la lógica que acabas de compilar
                    BLL.PartidaBLL bll = new BLL.PartidaBLL();

                    if (bll.EjecutarRegularizacionIVA())
                    {
                        MessageBox.Show("¡Partida de regularización de IVA calculada y registrada exitosamente!", "Cierre Automático", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                // Si no hay saldos suficientes o hay un error, el sistema le avisa al usuario sin crashear
                MessageBox.Show(ex.Message, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ejecutarCierreMensualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogo = MessageBox.Show("¿Está seguro de ejecutar el cierre contable del mes? Esto trasladará los saldos a Utilidades.", "Confirmar Cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (dialogo == DialogResult.Yes)
                {
                    BLL.PartidaBLL bll = new BLL.PartidaBLL();

                    if (bll.EjecutarPartidasDeCierre())
                    {
                        MessageBox.Show("¡Cierre mensual ejecutado exitosamente! Las cuentas de resultados han sido saldadas.", "Cierre Completo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ejecutar el cierre: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void libroDiarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLibroDiario frmDiario = new FormLibroDiario();
            frmDiario.ShowDialog();
        }

        private void libroMayorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLibroMayor frmMayor = new FormLibroMayor();
            frmMayor.ShowDialog();
        }

        private void estadosFinancierosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Abrimos el nuevo formulario de las pestañas
                FormEstadosFinancieros frmEstados = new FormEstadosFinancieros();
                frmEstados.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir los estados financieros: " + ex.Message);
            }
        }

        private void btnAgregarInventario_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Recopilar datos de los controles
                string sku = txtSku.Text.Trim();
                string descripcion = txtDescripcion.Text.Trim();
                string tipoItem = cmbTipoItem.Text;

                // 2. Validar y convertir los números (Usamos TryParse para que no crashee si meten letras)
                if (!decimal.TryParse(txtCosto.Text, out decimal costo))
                    throw new Exception("Ingrese un Costo Unitario válido (solo números).");

                if (!decimal.TryParse(txtPrecio.Text, out decimal precio))
                    throw new Exception("Ingrese un Precio de Venta válido (solo números).");

                if (!decimal.TryParse(txtExistencia.Text, out decimal existencia))
                    throw new Exception("Ingrese una cantidad de Existencia válida (solo números).");

                // 3. Mandar a guardar a la capa BLL correcta (ProductoBLL)
                BLL.ProductoBLL bll = new BLL.ProductoBLL();
                bool exito = bll.InsertarProducto(sku, descripcion, tipoItem, costo, precio, existencia);

                if (exito)
                {
                    MessageBox.Show("¡Producto agregado al inventario exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 4. Limpiar los cuadritos de texto para el siguiente ingreso
                    txtSku.Clear();
                    txtDescripcion.Clear();
                    txtCosto.Clear();
                    txtPrecio.Clear();
                    txtExistencia.Clear();
                    cmbTipoItem.SelectedIndex = -1;

    
                    CargarInventario();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvInventario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificamos que no hayan hecho clic en los encabezados
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvInventario.Rows[e.RowIndex];

                // Pasamos los datos a las cajitas
                txtSku.Text = fila.Cells["Sku"].Value.ToString();
                txtDescripcion.Text = fila.Cells["Descripcion"].Value.ToString();
                cmbTipoItem.Text = fila.Cells["TipoItem"].Value.ToString();
                txtCosto.Text = fila.Cells["CostoUnitario"].Value.ToString();
                txtPrecio.Text = fila.Cells["PrecioVenta"].Value.ToString();
                txtExistencia.Text = fila.Cells["Existencia"].Value.ToString();

                // Bloqueamos el SKU para que no le cambien el código y rompan la base de datos
                txtSku.ReadOnly = true;
            }
        }

        private void btnEliminarInventario_Click(object sender, EventArgs e)
        {
            try
            {
                string sku = txtSku.Text.Trim();
                if (string.IsNullOrEmpty(sku)) throw new Exception("Haga clic en un producto para eliminarlo.");

                // Preguntamos por seguridad
                DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea eliminar el producto " + sku + "?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    BLL.ProductoBLL bll = new BLL.ProductoBLL();
                    if (bll.EliminarProducto(sku))
                    {
                        MessageBox.Show("Producto eliminado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txtSku.Clear(); txtDescripcion.Clear(); txtCosto.Clear(); txtPrecio.Clear(); txtExistencia.Clear(); cmbTipoItem.SelectedIndex = -1;
                        txtSku.ReadOnly = false;

                        // Recargamos la tabla (pon aquí tu método de carga)
                        CargarInventario();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminarInventari_Click(object sender, EventArgs e)
        {
            try
            {
                string sku = txtSku.Text.Trim();
                if (string.IsNullOrEmpty(sku)) throw new Exception("Haga clic en un producto de la tabla para editarlo.");

                string descripcion = txtDescripcion.Text.Trim();
                string tipoItem = cmbTipoItem.Text;

                if (!decimal.TryParse(txtCosto.Text, out decimal costo)) throw new Exception("Costo inválido.");
                if (!decimal.TryParse(txtPrecio.Text, out decimal precio)) throw new Exception("Precio inválido.");
                if (!decimal.TryParse(txtExistencia.Text, out decimal existencia)) throw new Exception("Existencia inválida.");

                BLL.ProductoBLL bll = new BLL.ProductoBLL();
                if (bll.ActualizarProducto(sku, descripcion, tipoItem, costo, precio, existencia))
                {
                    MessageBox.Show("Producto actualizado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpiamos y desbloqueamos el SKU
                    txtSku.Clear(); txtDescripcion.Clear(); txtCosto.Clear(); txtPrecio.Clear(); txtExistencia.Clear(); cmbTipoItem.SelectedIndex = -1;
                    txtSku.ReadOnly = false;

                    // Recargamos la tabla (pon aquí tu método de carga)
                    CargarInventario();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
