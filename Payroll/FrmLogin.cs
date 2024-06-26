using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Payroll
{
    public partial class FrmLogin : Form
    {
        private readonly ApiClient _apiClient;
        public FrmLogin()
        {
            InitializeComponent();
            _apiClient = new ApiClient();
        }
        [DllImport("user32.dll")]
        private static extern int ReleaseCapture();
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hwnd, int msg, int wParam, int lParam);
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;
        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text == "Usuario")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.White;
            }
        }
        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                txtUser.Text = "Usuario";
                txtUser.ForeColor = Color.WhiteSmoke;
            }
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "Contraseña")
            {
                txtPass.Text = "";
                txtPass.ForeColor = Color.White;
                txtPass.UseSystemPasswordChar = true;

            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                txtPass.Text = "Contraseña";
                txtPass.ForeColor = Color.WhiteSmoke;
                txtPass.UseSystemPasswordChar = true;
            }
        }

        private void PBCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PBMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void FrmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void linkRegistro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var registroForm = new FrmRegister(_apiClient);
            registroForm.ShowDialog();
        }
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            await LoginAsync();
        }

        private async Task LoginAsync()
        {
            string username = txtUser.Text;
            string password = txtPass.Text;

            var token =
                await _apiClient.LoginUsers.AuthenticateUserAsync(username, password);

            if (!string.IsNullOrEmpty(token))
            {
                MessageBox.Show("Login successful!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Guardar el token para futuras solicitudes
                _apiClient.SetAuthToken(token);

                Hide();
                var mainForm = new FrmPrincipal(_apiClient);
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Login failed. Please check your username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FrmLogin_Load(object sender, EventArgs e)
        {
        }
    }
}
