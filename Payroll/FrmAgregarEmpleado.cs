using SharedModels.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace Payroll
{
    public partial class FrmAgregarEmpleado : Form
    {
        private readonly ApiClient _apiClient;
        public FrmAgregarEmpleado(ApiClient apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
        }
        private void txtPrimerNombre_Enter(object sender, EventArgs e)
        {
            if (txtPrimerNombre.Text == "Primer nombre")
                txtPrimerNombre.Text = "";
        }

        private void txtPrimerNombre_Leave(object sender, EventArgs e)
        {
            if (txtPrimerNombre.Text == "")
                txtPrimerNombre.Text = "Primer nombre";
        }

        private void txtPrimerApellido_Enter(object sender, EventArgs e)
        {
            if (txtPrimerApellido.Text == "Primer apellido")
                txtPrimerApellido.Text = "";
        }

        private void txtPrimerApellido_Leave(object sender, EventArgs e)
        {
            if (txtPrimerApellido.Text == "")
                txtPrimerApellido.Text = "Primer apellido";
        }


        private void txtNumeroCedula_Enter(object sender, EventArgs e)
        {
            if (txtNumeroCedula.Text == "Numero de cedula")
                txtNumeroCedula.Text = "";
        }

        private void txtNumeroCedula_Leave(object sender, EventArgs e)
        {
            if (txtNumeroCedula.Text == "")
                txtNumeroCedula.Text = "Numero de cedula";
        }

        private void txtDireccion_Enter(object sender, EventArgs e)
        {
            if (txtDireccion.Text == "Dirección")
                txtDireccion.Text = "";
        }

        private void txtDireccion_Leave(object sender, EventArgs e)
        {
            if (txtDireccion.Text == "")
                txtDireccion.Text = "Dirección";
        }

        private void txtTelefono_Enter(object sender, EventArgs e)
        {
            if (txtTelefono.Text == "Telefono")
                txtTelefono.Text = "";
        }

        private void txtTelefono_Leave(object sender, EventArgs e)
        {
            if (txtTelefono.Text == "")
                txtTelefono.Text = "Telefono";
        }

        private void txtCelular_Enter(object sender, EventArgs e)
        {
            if (txtCelular.Text == "Celular")
                txtCelular.Text = "";
        }

        private void txtCelular_Leave(object sender, EventArgs e)
        {
            if (txtCelular.Text == "")
                txtCelular.Text = "Celular";
        }

        private void txtSalarioBase_Enter(object sender, EventArgs e)
        {
            if (txtSalarioBase.Text == "Salario Base")
                txtSalarioBase.Text = "";
        }

        private void txtSalarioBase_Leave(object sender, EventArgs e)
        {
            if (txtSalarioBase.Text == "")
                txtSalarioBase.Text = "Salario Base";
        }

        private async void btnAgregarEmpleado_Click(object sender, EventArgs e)
        {
            if (!RBHombre.Checked && !RBMujer.Checked && !RBOtro.Checked)
            {
                MessageBox.Show("Debes seleccionar el sexo del empleado.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!RBCasado.Checked && !RBSoltero.Checked && !RBViudo.Checked)
            {
                MessageBox.Show("Debes seleccionar el estado civil del empleado.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var newEmployee = new EmployeeCreateDTO
            {
                FirstName = txtPrimerNombre.Text,
                LastName = txtPrimerApellido.Text,
                IdentificationNumber = txtNumeroCedula.Text,
                EmployeeNumber = txtEmployeeNumber.Text,
                IsActive = cbActivo.Checked,
                INSSNumber = txtINSS.Text,
                RUCNumber = txtINSS.Text,
                DateOfBirth = DateOnly.FromDateTime(dtpFechaNac.Value.Date),
                HireDate = DateOnly.FromDateTime(dtpFechaContratacion.Value.Date),
                Address = txtDireccion.Text,
                CellPhone = txtCelular.Text,
                Phone = txtTelefono.Text,
                Gender = SelectGender(),
                MaritalStatus = SelectMaritialStatus(),
                OrdinarySalary = decimal.Parse(txtSalarioBase.Text),
            };
            try
            {
                var success = await _apiClient.Employees.CreateAsync(newEmployee);
                MessageBox.Show("¡Empleado agregado correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputFields();
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show($"Error de conexión al servidor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar empleado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputFields()
        {
            txtPrimerNombre.Clear();
            txtPrimerApellido.Clear();
            txtNumeroCedula.Clear();
            txtEmployeeNumber.Clear();
            cbActivo.Checked = false;
            txtINSS.Clear();
            dtpFechaNac.Value = DateTime.Today;
            dtpFechaContratacion.Value = DateTime.Today;
            txtDireccion.Clear();
            txtCelular.Clear();
            txtTelefono.Clear();
            txtSalarioBase.Clear();
            RBCasado.Checked = false;
            RBSoltero.Checked = false;
            RBViudo.Checked = false; 
            RBHombre.Checked = false;
            RBMujer.Checked = false;
            RBOtro.Checked = false;
        }

        private string SelectMaritialStatus()
        {
            if (RBCasado.Checked)
                return "Casado";
            else if (RBSoltero.Checked)
                return "Soltero";
            else
                return "Viudo";
        }

        private string SelectGender()
        {
            if (RBHombre.Checked)
                return "Hombre";
            else if (RBMujer.Checked)
                return "Mujer";
            else
                return "otro";
        }
        private void FrmAgregarEmpleado_Load(object sender, EventArgs e)
        {
            
        }


    }
}
