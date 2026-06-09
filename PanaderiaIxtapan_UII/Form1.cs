using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices; // <-- Necesario para poder arrastrar la ventana
using BLL;
using Entidades;
using PanaderiaIxtapan_UII;

namespace PanaderiaIxtapan_UII
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // ── REDISEÑO HORIZONTAL — LOGIN ──────────────────────────────
            this.ClientSize = new Size(720, 440);
            this.BackColor = Color.FromArgb(27, 38, 49);
            this.StartPosition = FormStartPosition.CenterScreen;

            // ════════════════════════════════════════════
            //  PANEL IZQUIERDO — Branding
            // ════════════════════════════════════════════
            Panel pnlLeft = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(310, 440),
                BackColor = Color.FromArgb(27, 38, 49)
            };
            this.Controls.Add(pnlLeft);

            // Nombre de la empresa (pequeño, arriba)
            pnlLeft.Controls.Add(new Label
            {
                Text = "PANADERÍA IXTAPAN",
                Font = new Font("Segoe UI", 8.5f, FontStyle.Bold),
                ForeColor = Color.FromArgb(174, 214, 241),
                AutoSize = true,
                BackColor = Color.Transparent,
                Location = new Point(38, 44)
            });

            // Título grande "Bienvenido de Vuelta"
            pnlLeft.Controls.Add(new Label
            {
                Text = "Bienvenido",
                Font = new Font("Segoe UI Light", 27f),
                ForeColor = Color.White,
                AutoSize = true,
                BackColor = Color.Transparent,
                Location = new Point(36, 105)
            });
            pnlLeft.Controls.Add(new Label
            {
                Text = "de Vuelta.",
                Font = new Font("Segoe UI Light", 27f),
                ForeColor = Color.White,
                AutoSize = true,
                BackColor = Color.Transparent,
                Location = new Point(36, 152)
            });

            // Línea verde decorativa
            pnlLeft.Controls.Add(new Panel
            {
                Location = new Point(38, 212),
                Size = new Size(56, 3),
                BackColor = Color.FromArgb(30, 132, 73)
            });

            // Slogan
            pnlLeft.Controls.Add(new Label
            {
                Text = "El mejor pan de\nHuehuetenango.",
                Font = new Font("Segoe UI", 10.5f),
                ForeColor = Color.FromArgb(174, 214, 241),
                AutoSize = true,
                BackColor = Color.Transparent,
                Location = new Point(38, 226)
            });

            // Pie de panel izquierdo
            pnlLeft.Controls.Add(new Label
            {
                Text = "© 2026  Panadería Ixtapan",
                Font = new Font("Segoe UI", 7.5f),
                ForeColor = Color.FromArgb(74, 85, 104),
                AutoSize = true,
                BackColor = Color.Transparent,
                Location = new Point(38, 408)
            });

            // ════════════════════════════════════════════
            //  PANEL DERECHO — Formulario de login
            // ════════════════════════════════════════════
            Panel pnlRight = new Panel
            {
                Location = new Point(310, 0),
                Size = new Size(410, 440),
                BackColor = Color.White
            };
            this.Controls.Add(pnlRight);

            // Línea de acento azul en el borde izquierdo del panel
            pnlRight.Controls.Add(new Panel
            {
                Dock = DockStyle.Left,
                Width = 3,
                BackColor = Color.FromArgb(36, 113, 163)
            });

            // Título "Iniciar Sesión" — centrado
            pnlRight.Controls.Add(new Label
            {
                Text = "Iniciar Sesión",
                Font = new Font("Segoe UI", 18f, FontStyle.Bold),
                ForeColor = Color.FromArgb(27, 38, 49),
                AutoSize = false,
                Size = new Size(410, 40),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.Transparent,
                Location = new Point(0, 70)
            });

            // Línea decorativa bajo el título (centrada: (410-50)/2 = 180)
            pnlRight.Controls.Add(new Panel
            {
                Location = new Point(180, 116),
                Size = new Size(50, 2),
                BackColor = Color.FromArgb(36, 113, 163)
            });

            // Labels de campo
            pnlRight.Controls.Add(new Label
            {
                Text = "USUARIO",
                Font = new Font("Segoe UI", 8f, FontStyle.Bold),
                ForeColor = Color.FromArgb(113, 125, 126),
                AutoSize = true,
                BackColor = Color.Transparent,
                Location = new Point(65, 148)
            });
            pnlRight.Controls.Add(new Label
            {
                Text = "CONTRASEÑA",
                Font = new Font("Segoe UI", 8f, FontStyle.Bold),
                ForeColor = Color.FromArgb(113, 125, 126),
                AutoSize = true,
                BackColor = Color.Transparent,
                Location = new Point(65, 218)
            });

            // ── Mover controles existentes al panel derecho ───────────────
            // (los nombres NO cambian — los eventos siguen funcionando)

            pnlRight.Controls.Add(txtUsuario);
            txtUsuario.Location = new Point(65, 166);
            txtUsuario.Size = new Size(280, 28);
            txtUsuario.BackColor = Color.FromArgb(240, 243, 248);
            txtUsuario.BorderStyle = BorderStyle.FixedSingle;
            txtUsuario.Font = new Font("Segoe UI", 10f);

            pnlRight.Controls.Add(txtPassword);
            txtPassword.Location = new Point(65, 236);
            txtPassword.Size = new Size(280, 28);
            txtPassword.BackColor = Color.FromArgb(240, 243, 248);
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 10f);

            pnlRight.Controls.Add(btnLogin);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatAppearance.MouseOverBackColor = Color.FromArgb(21, 82, 128);
            btnLogin.FlatAppearance.MouseDownBackColor = Color.FromArgb(13, 63, 110);
            btnLogin.BackColor = Color.FromArgb(36, 113, 163);
            btnLogin.ForeColor = Color.White;
            btnLogin.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.Location = new Point(65, 298);
            btnLogin.Size = new Size(280, 38);
            btnLogin.Text = "INGRESAR AL SISTEMA";

            // Botón X cerrar — esquina superior derecha del panel derecho
            pnlRight.Controls.Add(label1);
            label1.Font = new Font("Segoe UI", 11f, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(113, 125, 126);
            label1.BackColor = Color.Transparent;
            label1.Cursor = Cursors.Hand;
            label1.Location = new Point(378, 10);

            pnlRight.BringToFront();
        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioBLL bll = new UsuarioBLL();

                // Llamamos a la capa lógica para validar y autenticar
                Usuario usuarioLogueado = bll.Autenticar(txtUsuario.Text, txtPassword.Text);

                if (usuarioLogueado != null)
                {
                    // Un pequeño toque personalizado
                    MessageBox.Show($"Hola amigoide, {usuarioLogueado.NombreCompleto}!", "Pase adelante", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // AHORA SÍ: Abrimos el menú principal contable (sin las diagonales //)
                    FormPrincipal main = new FormPrincipal();
                    main.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos, o cuenta inactiva.", "Error de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Atrapa si envían campos vacíos
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
