using SharedModels.Dto;
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
    public partial class FrmRegister : Form
    {
        private readonly ApiClient _apiClient;
        private string _authToken;
        public FrmRegister(ApiClient apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
        }
        [DllImport("user32.dll")]
        private static extern int ReleaseCapture();
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hwnd, int msg, int wParam, int lParam);
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;
        private void PBCerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void PBMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void FrmRegister_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void txtPrimerNombre_Enter(object sender, EventArgs e)
        {
            if (txtPrimerNombre.Text == "Primer nombre")
            {
                txtPrimerNombre.Text = "";
                txtPrimerNombre.ForeColor = Color.White;
            }
        }

        private void txtPrimerNombre_Leave(object sender, EventArgs e)
        {
            if (txtPrimerNombre.Text == "")
            {
                txtPrimerNombre.Text = "Primer nombre";
                txtPrimerNombre.ForeColor = Color.WhiteSmoke;
            }
        }
        

        private void txtSegundoApellido_Enter(object sender, EventArgs e)
        {
            if (txtSegundoApellido.Text == "Segundo apellido")
            {
                txtSegundoApellido.Text = "";
                txtSegundoApellido.ForeColor = Color.White;
            }
        }

        private void txtSegundoApellido_Leave(object sender, EventArgs e)
        {
            if (txtSegundoApellido.Text == "")
            {
                txtSegundoApellido.Text = "Segundo apellido";
                txtSegundoApellido.ForeColor = Color.WhiteSmoke;
            }
        }

        private void txtCorreo_Enter(object sender, EventArgs e)
        {
            if (txtCorreo.Text == "Correo electronico")
            {
                txtCorreo.Text = "";
                txtCorreo.ForeColor = Color.White;
            }
        }

        private void txtCorreo_Leave(object sender, EventArgs e)
        {
            if (txtCorreo.Text == "")
            {
                txtCorreo.Text = "Correo electronico";
                txtCorreo.ForeColor = Color.WhiteSmoke;
            }

        }

        private void txtUserRegist_Enter(object sender, EventArgs e)
        {
            if (txtUserRegist.Text == "Usuario")
            {
                txtUserRegist.Text = "";
                txtUserRegist.ForeColor = Color.White;
            }
        }

        private void txtUserRegist_Leave(object sender, EventArgs e)
        {
            if (txtUserRegist.Text == "")
            {
                txtUserRegist.Text = "Usuario";
                txtUserRegist.ForeColor = Color.WhiteSmoke;
            }
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "Contraseña")
            {
                txtPass.Text = "";
                txtPass.ForeColor = Color.White;
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                txtPass.Text = "Contraseña";
                txtPass.ForeColor = Color.WhiteSmoke;
            }
        }

        private void txtConfirmPass_Enter(object sender, EventArgs e)
        {
            if (txtConfirmPass.Text == "Repetir contraseña")
            {
                txtConfirmPass.Text = "";
                txtConfirmPass.ForeColor = Color.White;
            }
        }

        private void txtConfirmPass_Leave(object sender, EventArgs e)
        {
            if (txtConfirmPass.Text == "")
            {
                txtConfirmPass.Text = "Repetir contraseña";
                txtConfirmPass.ForeColor = Color.WhiteSmoke;
            }
        }
       
        private async void btnRegsitrar_Click(object sender, EventArgs e)
        {
            string username = txtUserRegist.Text;
            string password = txtPass.Text;
            string confirmPassword = txtConfirmPass.Text;

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match. Please re-enter.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var registerDTO = new RegisterUserDTO
            {
                UserName = username,
                Password = password,
                Email = txtCorreo.Text
            };

            try
            {
                // Registro de usuario y obtención de token JWT
                _authToken = await _apiClient.RegisterUserAndGetTokenAsync(registerDTO);

                // Configurar el ApiClient con el token JWT recibido
                _apiClient.SetAuthToken(_authToken);

                MessageBox.Show("User registered successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Cerrar el formulario de registro después de un registro exitoso
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"HTTP request failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FrmRegister_Load(object sender, EventArgs e)
        {
        }
    }
}
