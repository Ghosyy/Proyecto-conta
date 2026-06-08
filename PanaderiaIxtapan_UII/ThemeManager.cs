using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PanaderiaIxtapan_UI // Ajusta a tu namespace
{
    public static class ThemeManager
    {
        // Paleta de colores
        private static readonly Color ColorFondo = Color.White;
        private static readonly Color ColorPrimario = ColorTranslator.FromHtml("#1A2530");
        private static readonly Color ColorTextoSecundario = ColorTranslator.FromHtml("#5C6B7B");
        private static readonly Color ColorHover = ColorTranslator.FromHtml("#2C3E50");

        // Fuentes
        private static readonly Font FuenteTituloGrande = new Font("Segoe UI", 24F, FontStyle.Bold);
        private static readonly Font FuenteTituloGeneral = new Font("Segoe UI", 18F, FontStyle.Bold);
        private static readonly Font FuenteGeneral = new Font("Segoe UI", 10F, FontStyle.Regular);

        /// <summary>
        /// 1. MÉTODO PARA EL LOGIN: Parte la pantalla y crea el diseño moderno.
        /// </summary>
        public static void GenerarLoginModerno(Form formLogin)
        {
            formLogin.BackColor = ColorFondo;
            formLogin.FormBorderStyle = FormBorderStyle.Sizable; // O None si prefieres
            formLogin.MinimumSize = new Size(800, 500);

            // Panel Derecho (Color Marino)
            Panel panelDerecho = new Panel
            {
                Dock = DockStyle.Right,
                Width = formLogin.Width / 2,
                BackColor = ColorPrimario
            };

            // Título dentro del Panel Derecho
            Label lblTituloDerecho = new Label
            {
                Text = "Panadería Ixtapan",
                ForeColor = Color.White,
                Font = FuenteTituloGrande,
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label lblSubtitulo = new Label
            {
                Text = "Tradición y control contable",
                ForeColor = Color.LightGray,
                Font = new Font("Segoe UI", 12F, FontStyle.Italic),
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Centrar textos en el panel derecho usando el evento Resize del panel
            panelDerecho.Resize += (s, e) =>
            {
                lblTituloDerecho.Location = new Point((panelDerecho.Width - lblTituloDerecho.Width) / 2, (panelDerecho.Height / 2) - 30);
                lblSubtitulo.Location = new Point((panelDerecho.Width - lblSubtitulo.Width) / 2, lblTituloDerecho.Bottom + 10);
            };

            panelDerecho.Controls.Add(lblTituloDerecho);
            panelDerecho.Controls.Add(lblSubtitulo);
            formLogin.Controls.Add(panelDerecho);

            // Estilizar los controles existentes en la izquierda (TextBoxes, Botones)
            AplicarEstilosBasicos(formLogin.Controls);

            // Título de "Iniciar Sesión" en la izquierda
            Label lblLogin = new Label
            {
                Text = "Iniciar Sesión",
                ForeColor = ColorPrimario,
                Font = FuenteTituloGrande,
                AutoSize = true,
                Location = new Point(50, 50) // Posición fija superior izquierda
            };
            formLogin.Controls.Add(lblLogin);

            // Asegurarnos que el panel derecho siempre ocupe la mitad al maximizar
            formLogin.Resize += (s, e) => panelDerecho.Width = formLogin.Width / 2;
        }

        /// <summary>
        /// 2. MÉTODO PARA FORMULARIOS GRANDES: Centra todo, pone títulos y estiliza.
        /// </summary>
        public static void AplicarEstiloYCentrar(Form form, string tituloFormulario)
        {
            form.BackColor = ColorFondo;
            form.Font = FuenteGeneral;

            // a. Agregar Título Gigante Arriba
            Label lblTitulo = new Label
            {
                Text = tituloFormulario.ToUpper(),
                Font = FuenteTituloGeneral,
                ForeColor = ColorPrimario,
                AutoSize = true,
                Location = new Point(30, 20)
            };
            form.Controls.Add(lblTitulo);

            // b. Crear un "Contenedor Maestro" para centrar todo dinámicamente
            Panel panelContenedor = new Panel
            {
                BackColor = Color.Transparent,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink
            };

            // Mover todos los controles existentes (excepto el título nuevo) al panel contenedor
            var controlesAMover = form.Controls.Cast<Control>().Where(c => c != lblTitulo && c != panelContenedor).ToList();
            foreach (Control ctrl in controlesAMover)
            {
                ctrl.Parent = panelContenedor;
            }

            form.Controls.Add(panelContenedor);

            // Lógica para mantener todo centrado al redimensionar/maximizar
            form.Resize += (s, e) =>
            {
                panelContenedor.Left = (form.ClientSize.Width - panelContenedor.Width) / 2;
                panelContenedor.Top = ((form.ClientSize.Height - panelContenedor.Height) / 2) + 30; // Un poco más abajo por el título
            };

            // Disparar el resize una vez para ajustar ahorita
            // Disparar el ajuste inicial manualmente (Solución al error CS0122)
            panelContenedor.Left = (form.ClientSize.Width - panelContenedor.Width) / 2;
            panelContenedor.Top = ((form.ClientSize.Height - panelContenedor.Height) / 2) + 30;

            // c. Aplicar estilos a DataGridViews, Botones y Textboxes
            AplicarEstilosBasicos(panelContenedor.Controls);
        }

        /// <summary>
        /// 3. EL MOTOR DE ESTILOS: Recorre y embellece los controles
        /// </summary>
        private static void AplicarEstilosBasicos(Control.ControlCollection controles)
        {
            foreach (Control ctrl in controles)
            {
                if (ctrl is Button btn)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.BackColor = ColorPrimario;
                    btn.ForeColor = Color.White;
                    btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                    btn.Cursor = Cursors.Hand;
                    btn.Height = 40;
                    btn.MouseEnter += (s, e) => btn.BackColor = ColorHover;
                    btn.MouseLeave += (s, e) => btn.BackColor = ColorPrimario;
                }
                else if (ctrl is TextBox txt)
                {
                    txt.BorderStyle = BorderStyle.FixedSingle;
                    txt.Font = FuenteGeneral;
                }
                else if (ctrl is DataGridView dgv)
                {
                    dgv.EnableHeadersVisualStyles = false;
                    dgv.BackgroundColor = ColorFondo;
                    dgv.BorderStyle = BorderStyle.None;
                    dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                    dgv.GridColor = ColorTranslator.FromHtml("#EEEEEE");
                    dgv.RowHeadersVisible = false;

                    dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
                    dgv.ColumnHeadersDefaultCellStyle.BackColor = ColorPrimario;
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                    dgv.ColumnHeadersHeight = 45;

                    dgv.DefaultCellStyle.SelectionBackColor = ColorHover;
                    dgv.DefaultCellStyle.SelectionForeColor = Color.White;
                    dgv.RowTemplate.Height = 40;
                    dgv.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#F8F9FA");
                }
                else if (ctrl is Panel || ctrl is GroupBox)
                {
                    AplicarEstilosBasicos(ctrl.Controls); // Recursividad
                }
                else if (ctrl is Label lbl)
                {
                    // Solo cambiar a gris los labels pequeños que sean subtítulos
                    if (lbl.Font.Size <= 10)
                    {
                        lbl.ForeColor = ColorTextoSecundario;
                    }
                }
            }
        }
    }
}