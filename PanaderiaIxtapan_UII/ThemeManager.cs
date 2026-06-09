using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PanaderiaIxtapan_UII
{
    // ================================================================
    //  CLASE PRINCIPAL
    // ================================================================
    public static class ThemeManager
    {
        // ─────────────────────────────────────────────────────────────
        //  PALETA DE COLORES
        //  Extraída de la imagen de referencia: fondo blanco limpio,
        //  encabezados azul marino oscuro, tipografía refinada.
        // ─────────────────────────────────────────────────────────────

        // Fondos
        public static readonly Color ColorFondo = Color.FromArgb(240, 243, 248); // Gris azulado muy claro
        public static readonly Color ColorSuperficie = Color.White;                    // Tarjetas y grillas

        // Cabeceras y barras de navegación
        public static readonly Color ColorHeader = Color.FromArgb(27, 38, 49);    // Azul marino oscuro
        public static readonly Color ColorHeaderTexto = Color.White;

        // Botón Primario (azul — acción estándar)
        public static readonly Color ColorPrimario = Color.FromArgb(36, 113, 163);
        public static readonly Color ColorPrimarioHover = Color.FromArgb(21, 82, 128);
        public static readonly Color ColorPrimarioClick = Color.FromArgb(13, 63, 110);

        // Botón Éxito (verde — Agregar, Guardar, Generar IVA)
        public static readonly Color ColorExito = Color.FromArgb(30, 132, 73);
        public static readonly Color ColorExitoHover = Color.FromArgb(17, 100, 55);
        public static readonly Color ColorExitoClick = Color.FromArgb(11, 72, 40);

        // Botón Peligro (rojo — Eliminar)
        public static readonly Color ColorPeligro = Color.FromArgb(192, 57, 43);
        public static readonly Color ColorPeligroHover = Color.FromArgb(146, 43, 33);
        public static readonly Color ColorPeligroClick = Color.FromArgb(110, 30, 23);

        // Botón Secundario (gris azulado — Editar, Actualizar)
        public static readonly Color ColorSecundario = Color.FromArgb(93, 109, 126);
        public static readonly Color ColorSecundarioHover = Color.FromArgb(74, 85, 104);
        public static readonly Color ColorSecundarioClick = Color.FromArgb(55, 65, 81);

        // Texto
        public static readonly Color ColorTexto = Color.FromArgb(27, 38, 49);    // Texto principal
        public static readonly Color ColorTextoSecundario = Color.FromArgb(113, 125, 126); // Labels de campo
        public static readonly Color ColorTextoMuted = Color.FromArgb(174, 182, 191); // Placeholder / inactivo

        // Bordes e inputs
        public static readonly Color ColorBorde = Color.FromArgb(213, 216, 220);

        // DataGridView
        public static readonly Color ColorGridHeader = Color.FromArgb(27, 38, 49);    // Cabecera oscura
        public static readonly Color ColorFilaAlterna = Color.FromArgb(242, 244, 247); // Fila gris muy sutil
        public static readonly Color ColorSeleccion = Color.FromArgb(174, 214, 241); // Selección azul claro
        public static readonly Color ColorSeleccionTexto = Color.FromArgb(27, 38, 49);

        // ─────────────────────────────────────────────────────────────
        //  TIPOGRAFÍA
        // ─────────────────────────────────────────────────────────────

        public static readonly Font FuenteBase = new Font("Segoe UI", 9.5f, FontStyle.Regular);
        public static readonly Font FuenteTitulo = new Font("Segoe UI", 10.5f, FontStyle.Bold);
        public static readonly Font FuenteHeader = new Font("Segoe UI", 9f, FontStyle.Bold);
        public static readonly Font FuenteLabel = new Font("Segoe UI", 9f, FontStyle.Regular);
        public static readonly Font FuenteNegrita = new Font("Segoe UI", 9.5f, FontStyle.Bold);
        public static readonly Font FuenteSistema = new Font("Segoe UI", 13f, FontStyle.Regular);
        public static readonly Font FuenteTotal = new Font("Segoe UI", 10f, FontStyle.Bold);

        // ─────────────────────────────────────────────────────────────
        //  ENUMERADOR DE TIPOS DE BOTÓN
        // ─────────────────────────────────────────────────────────────

        public enum TipoBoton
        {
            Primario,   // Azul — acción estándar
            Exito,      // Verde — agregar, guardar, confirmar
            Peligro,    // Rojo — eliminar
            Secundario  // Gris — editar, actualizar, neutral
        }

        // ================================================================
        //  MÉTODO PRINCIPAL — llama este en el constructor de cada Form
        // ================================================================

        /// <summary>
        /// Aplica el tema completo a un Form y todos sus controles hijos.
        /// Llamar: ThemeManager.AplicarTema(this);
        /// Ubicación: En el constructor del Form, DESPUÉS de InitializeComponent().
        /// </summary>
        public static void AplicarTema(Form form)
        {
            form.BackColor = ColorFondo;
            form.Font = FuenteBase;
            form.ForeColor = ColorTexto;

            RecorrerControles(form.Controls);
        }

        // ================================================================
        //  MÉTODOS PÚBLICOS INDIVIDUALES
        //  Úsalos para sobreescribir el tipo de botón que AplicarTema
        //  detecta automáticamente, o para estilizar controles que
        //  agregas dinámicamente.
        // ================================================================

        /// <summary>
        /// Aplica estilo moderno a un DataGridView.
        /// </summary>
        public static void EstilizarGrid(DataGridView dgv)
        {
            // Estructura general
            dgv.BorderStyle = BorderStyle.None;
            dgv.BackgroundColor = ColorSuperficie;
            dgv.GridColor = ColorBorde;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToResizeRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.Font = FuenteBase;

            // Cabeceras
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersHeight = 36;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = ColorGridHeader,
                ForeColor = Color.White,
                Font = FuenteHeader,
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                Padding = new Padding(10, 0, 0, 0)
            };

            // Filas normales
            dgv.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = ColorSuperficie,
                ForeColor = ColorTexto,
                Font = FuenteBase,
                SelectionBackColor = ColorSeleccion,
                SelectionForeColor = ColorSeleccionTexto,
                Padding = new Padding(6, 0, 6, 0)
            };
            dgv.RowTemplate.Height = 30;

            // Filas alternadas — sutil diferencia de tono
            dgv.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = ColorFilaAlterna,
                ForeColor = ColorTexto,
                SelectionBackColor = ColorSeleccion,
                SelectionForeColor = ColorSeleccionTexto
            };
        }

        /// <summary>
        /// Aplica estilo a un botón detectando automáticamente el tipo
        /// según el nombre del control (btnAgregar → Éxito, btnEliminar → Peligro, etc.)
        /// Para especificar el tipo manualmente usa la sobrecarga con TipoBoton.
        /// </summary>
        public static void EstilizarBoton(Button btn)
        {
            EstilizarBoton(btn, DetectarTipoBoton(btn.Name));
        }

        /// <summary>
        /// Aplica estilo a un botón con tipo explícito.
        /// ÚSALO para sobreescribir la detección automática.
        /// Ej: ThemeManager.EstilizarBoton(btnEliminarInventari, ThemeManager.TipoBoton.Secundario);
        /// </summary>
        public static void EstilizarBoton(Button btn, TipoBoton tipo)
        {
            Color colorFondo, colorHover, colorClick;

            switch (tipo)
            {
                case TipoBoton.Exito:
                    colorFondo = ColorExito;
                    colorHover = ColorExitoHover;
                    colorClick = ColorExitoClick;
                    break;
                case TipoBoton.Peligro:
                    colorFondo = ColorPeligro;
                    colorHover = ColorPeligroHover;
                    colorClick = ColorPeligroClick;
                    break;
                case TipoBoton.Secundario:
                    colorFondo = ColorSecundario;
                    colorHover = ColorSecundarioHover;
                    colorClick = ColorSecundarioClick;
                    break;
                default: // Primario
                    colorFondo = ColorPrimario;
                    colorHover = ColorPrimarioHover;
                    colorClick = ColorPrimarioClick;
                    break;
            }

            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = colorHover;
            btn.FlatAppearance.MouseDownBackColor = colorClick;
            btn.BackColor = colorFondo;
            btn.ForeColor = Color.White;
            btn.Font = FuenteNegrita;
            btn.Cursor = Cursors.Hand;
            btn.TextAlign = ContentAlignment.MiddleCenter;
            btn.Padding = new Padding(0, 2, 0, 2);
        }

        /// <summary>
        /// Aplica estilo moderno a un TextBox.
        /// </summary>
        public static void EstilizarTextBox(TextBox txt)
        {
            txt.BorderStyle = BorderStyle.FixedSingle;
            txt.BackColor = ColorSuperficie;
            txt.ForeColor = ColorTexto;
            txt.Font = FuenteBase;
        }

        /// <summary>
        /// Aplica estilo moderno a un ComboBox.
        /// </summary>
        public static void EstilizarComboBox(ComboBox cmb)
        {
            cmb.FlatStyle = FlatStyle.Flat;
            cmb.BackColor = ColorSuperficie;
            cmb.ForeColor = ColorTexto;
            cmb.Font = FuenteBase;
        }

        /// <summary>
        /// Aplica tema oscuro profesional al MenuStrip de navegación.
        /// </summary>
        public static void EstilizarMenuStrip(MenuStrip menu)
        {
            menu.BackColor = ColorHeader;
            menu.ForeColor = Color.White;
            menu.Font = new Font("Segoe UI", 9.5f);
            menu.Padding = new Padding(6, 2, 0, 2);
            menu.Renderer = new ToolStripProfessionalRenderer(new MenuColorTable());

            foreach (ToolStripItem item in menu.Items)
            {
                item.ForeColor = Color.White;
                item.BackColor = ColorHeader;
                item.Font = new Font("Segoe UI", 9.5f);
                item.Padding = new Padding(8, 0, 8, 0);

                if (item is ToolStripMenuItem tsmi)
                    EstilizarSubItems(tsmi);
            }
        }

        /// <summary>
        /// Aplica estilo a un TabControl con pestañas dibujadas a mano.
        /// El ThemeManager suscribe el evento DrawItem internamente —
        /// no necesitas hacer nada más.
        /// </summary>
        public static void EstilizarTabControl(TabControl tab)
        {
            tab.DrawMode = TabDrawMode.OwnerDrawFixed;
            tab.Font = FuenteBase;
            tab.SizeMode = TabSizeMode.Fixed;
            tab.ItemSize = new Size(170, 34);
            tab.Padding = new Point(16, 6);

            // Evitar doble suscripción si se llama más de una vez
            tab.DrawItem -= TabControl_DrawItem;
            tab.DrawItem += TabControl_DrawItem;
        }

        /// <summary>
        /// Aplica estilo moderno al DateTimePicker.
        /// </summary>
        public static void EstilizarDateTimePicker(DateTimePicker dtp)
        {
            dtp.Font = FuenteBase;
            dtp.CalendarForeColor = ColorTexto;
            dtp.CalendarMonthBackground = ColorSuperficie;
            dtp.CalendarTitleBackColor = ColorHeader;
            dtp.CalendarTitleForeColor = Color.White;
            dtp.CalendarTrailingForeColor = ColorTextoMuted;
        }

        /// <summary>
        /// Aplica estilo a una etiqueta (Label).
        /// esEncabezadoSeccion = true → fuente grande, texto oscuro.
        /// esEncabezadoSeccion = false → fuente small, gris secundario.
        /// </summary>
        public static void EstilizarLabel(Label lbl, bool esEncabezadoSeccion = false)
        {
            if (esEncabezadoSeccion)
            {
                lbl.Font = FuenteTitulo;
                lbl.ForeColor = ColorTexto;
            }
            else
            {
                lbl.Font = FuenteLabel;
                lbl.ForeColor = ColorTextoSecundario;
            }
        }

        /// <summary>
        /// Crea y agrega un Label de encabezado de sección al formulario padre.
        /// Devuelve el Label para ajustes adicionales.
        /// Uso: ThemeManager.AgregarEncabezadoSeccion(this, "CATÁLOGO DE CUENTAS", 12, 35);
        /// </summary>
        public static Label AgregarEncabezadoSeccion(Form padre, string texto, int x, int y)
        {
            // Panel borde izquierdo de acento
            Panel acento = new Panel
            {
                Location = new Point(x, y),
                Size = new Size(4, 20),
                BackColor = ColorPrimario
            };

            Label lbl = new Label
            {
                Text = texto,
                Font = FuenteTitulo,
                ForeColor = ColorTexto,
                AutoSize = true,
                Location = new Point(x + 10, y),
                BackColor = Color.Transparent
            };

            padre.Controls.Add(acento);
            padre.Controls.Add(lbl);
            lbl.BringToFront();
            acento.BringToFront();

            return lbl;
        }

        /// <summary>
        /// Crea y agrega un Panel de encabezado del sistema en la parte superior del Form.
        /// Incluye el título del sistema y se integra visualmente con el MenuStrip existente.
        /// 
        /// ¡IMPORTANTE! Llama este método ANTES de AplicarTema() en el constructor:
        ///     Panel bar = ThemeManager.CrearBarraSistema(this, menuStrip1, "Sistema Contable · Panadería Ixtapan");
        ///     ThemeManager.AplicarTema(this);
        /// </summary>
        public static Panel CrearBarraSistema(Form padre, MenuStrip menuStrip, string nombreSistema)
        {
            // Panel oscuro que hace de TopBar visual
            Panel barra = new Panel
            {
                BackColor = ColorHeader,
                Dock = DockStyle.Top,
                Height = 48
            };

            Label lblNombre = new Label
            {
                Text = nombreSistema,
                Font = FuenteSistema,
                ForeColor = Color.White,
                AutoSize = true,
                BackColor = Color.Transparent,
                Location = new Point(14, 12)
            };

            barra.Controls.Add(lblNombre);
            padre.Controls.Add(barra);
            barra.BringToFront();

            // Asegurar que el MenuStrip quede debajo de la barra
            menuStrip.Parent?.Controls.SetChildIndex(menuStrip, padre.Controls.IndexOf(barra) + 1);

            return barra;
        }

        // ================================================================
        //  MÉTODOS PRIVADOS / HELPERS INTERNOS
        // ================================================================

        private static void RecorrerControles(Control.ControlCollection controles)
        {
            foreach (Control ctrl in controles)
            {
                switch (ctrl)
                {
                    case MenuStrip menu:
                        EstilizarMenuStrip(menu);
                        break; // No recursamos dentro del MenuStrip

                    case DataGridView dgv:
                        EstilizarGrid(dgv);
                        break; // No recursamos dentro del DGV

                    case TabControl tab:
                        EstilizarTabControl(tab);
                        if (ctrl.HasChildren) RecorrerControles(ctrl.Controls);
                        break;

                    case TabPage tp:
                        tp.BackColor = ColorSuperficie;
                        if (ctrl.HasChildren) RecorrerControles(ctrl.Controls);
                        break;

                    case Button btn:
                        EstilizarBoton(btn);
                        break;

                    case TextBox txt:
                        EstilizarTextBox(txt);
                        break;

                    case ComboBox cmb:
                        EstilizarComboBox(cmb);
                        break;

                    case Label lbl:
                        EstilizarLabel(lbl);
                        break;

                    case DateTimePicker dtp:
                        EstilizarDateTimePicker(dtp);
                        break;

                    case GroupBox grp:
                        grp.Font = FuenteLabel;
                        grp.ForeColor = ColorTextoSecundario;
                        if (ctrl.HasChildren) RecorrerControles(ctrl.Controls);
                        break;

                    case Panel pnl:
                        // Solo cambia el fondo si está en el color por defecto de Windows
                        if (pnl.BackColor == SystemColors.Control)
                            pnl.BackColor = ColorFondo;
                        if (ctrl.HasChildren) RecorrerControles(ctrl.Controls);
                        break;

                    default:
                        if (ctrl.HasChildren) RecorrerControles(ctrl.Controls);
                        break;
                }
            }
        }

        private static TipoBoton DetectarTipoBoton(string nombre)
        {
            string n = (nombre ?? "").ToLowerInvariant();

            // Éxito: acciones de creación y confirmación
            if (n.Contains("agregar") || n.Contains("guardar") ||
                n.Contains("nuevo") || n.Contains("generar") ||
                n.Contains("iva") || n.Contains("confirmar"))
                return TipoBoton.Exito;

            // Peligro: eliminación destructiva
            // NOTA: "btnEliminarInventari" (sin 'o') es en realidad editar —
            // sobreescribir explícitamente en FormPrincipal con TipoBoton.Secundario
            if (n == "btneliminarinventario" || n.Contains("borrar") || n.Contains("cancelar"))
                return TipoBoton.Peligro;

            // Secundario: edición y actualización
            if (n.Contains("actualizar") || n.Contains("editar") ||
                n.Contains("modificar") || n.Contains("btneliminarinventari"))
                return TipoBoton.Secundario;

            return TipoBoton.Primario;
        }

        private static void EstilizarSubItems(ToolStripMenuItem item)
        {
            item.ForeColor = Color.White;
            item.BackColor = ColorHeader;
            item.Font = new Font("Segoe UI", 9.5f);

            foreach (ToolStripItem sub in item.DropDownItems)
            {
                sub.ForeColor = ColorTexto;
                sub.BackColor = ColorSuperficie;
                sub.Font = new Font("Segoe UI", 9.5f);

                if (sub is ToolStripMenuItem subItem)
                    EstilizarSubItems(subItem);
            }
        }

        // Dibuja las pestañas del TabControl con el estilo del tema
        private static void TabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (!(sender is TabControl tab)) return;
            TabPage pag = tab.TabPages[e.Index];
            bool activa = (e.Index == tab.SelectedIndex);

            Color fondoTab = activa ? ColorPrimario : Color.FromArgb(44, 62, 80);
            Color textoTab = Color.White;

            using (SolidBrush brFondo = new SolidBrush(fondoTab))
                e.Graphics.FillRectangle(brFondo, e.Bounds);

            using (SolidBrush brTexto = new SolidBrush(textoTab))
            {
                StringFormat sf = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                e.Graphics.DrawString(pag.Text, FuenteHeader, brTexto, e.Bounds, sf);
            }

            // Línea verde inferior para la pestaña activa
            if (activa)
            {
                using (Pen pen = new Pen(ColorExito, 3))
                    e.Graphics.DrawLine(pen,
                        e.Bounds.Left,
                        e.Bounds.Bottom - 3,
                        e.Bounds.Right,
                        e.Bounds.Bottom - 3);
            }
        }
    }

    // ================================================================
    //  COLOR TABLE PARA EL MENUSTRIP
    //  Elimina los bordes y gradientes grises por defecto de Windows
    // ================================================================
    internal sealed class MenuColorTable : ProfessionalColorTable
    {
        private static readonly Color Oscuro = Color.FromArgb(27, 38, 49);
        private static readonly Color Hover = Color.FromArgb(41, 128, 185);
        private static readonly Color Blanco = Color.White;
        private static readonly Color Separador = Color.FromArgb(213, 216, 220);

        public override Color MenuItemSelected => Hover;
        public override Color MenuItemBorder => Hover;
        public override Color MenuItemSelectedGradientBegin => Hover;
        public override Color MenuItemSelectedGradientEnd => Hover;
        public override Color MenuItemPressedGradientBegin => Oscuro;
        public override Color MenuItemPressedGradientEnd => Oscuro;
        public override Color MenuBorder => Separador;
        public override Color MenuStripGradientBegin => Oscuro;
        public override Color MenuStripGradientEnd => Oscuro;
        public override Color ToolStripDropDownBackground => Blanco;
        public override Color ImageMarginGradientBegin => Blanco;
        public override Color ImageMarginGradientMiddle => Blanco;
        public override Color ImageMarginGradientEnd => Blanco;
        public override Color ToolStripBorder => Separador;
        public override Color SeparatorDark => Separador;
        public override Color SeparatorLight => Blanco;
        public override Color CheckBackground => Hover;
        public override Color CheckSelectedBackground => Hover;
        public override Color CheckPressedBackground => Color.FromArgb(21, 82, 128);
    }
}