using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            await LoginAsync();
        }

        private async Task LoginAsync()
        {
            string username = txtUser.Text;
            string password = txtPassword.Text;

            var token =
                await _apiClient.LoginUsers.AuthenticateUserAsync(username, password);

            if (!string.IsNullOrEmpty(token))
            {
                MessageBox.Show("Login successful!");

                // Guardar el token para futuras solicitudes
                _apiClient.SetAuthToken(token);

                Hide();
                var mainForm = new FrmPrincipal(_apiClient);
                mainForm.Show();
            }
            else
            {
                MessageBox.Show("Login failed. Please check your username and password.");
            }
        }
    }
}
