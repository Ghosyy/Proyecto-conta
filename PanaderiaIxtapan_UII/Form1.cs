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
using PanaderiaIxtapan_UI;

namespace PanaderiaIxtapan_UII
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ThemeManager.GenerarLoginModerno(this);
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
                    MessageBox.Show($"¡Bienvenido inge, {usuarioLogueado.NombreCompleto}!", "Login Exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
