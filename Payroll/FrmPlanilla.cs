using SharedModels.Dto;
using SharedModels.Entidades;
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
    public partial class FrmPlanilla : Form
    {
        private readonly ApiClient _apiClient;
        private EmployeeDTO _selectedEmployee;
        public FrmPlanilla(ApiClient apiClient)
        {
            InitializeComponent();
            _apiClient = apiClient;
        }
        private async void FrmPlanilla_Load(object sender, EventArgs e)
        {
            await LoadEmployeesAsync();
        }

        private async Task LoadEmployeesAsync()
        {

            try
            {
                var employees = await _apiClient.Employees.GetAllAsync();
                dgvdEmployees.DataSource = employees.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar empleados: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            string searchTerm = txtBusqueda.Text.Trim();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                try
                {
                    // Llamar al método SearchEmployeesAsync del ApiClient para obtener empleados filtrados
                    var employees = await _apiClient.SearchEmployeesAsync(searchTerm);

                    if (employees.Any())
                    {
                        dgvdEmployees.DataSource = employees.ToList();
                    }
                    else
                    {
                        MessageBox.Show("No se encontraron empleados que coincidan con la búsqueda.", "Búsqueda sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al buscar empleados: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un término de búsqueda.", "Búsqueda vacía", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            txtBusqueda.Text = "";
        }
        private async void btnCalcular_Click(object sender, EventArgs e)
        {
            if (_selectedEmployee != null && ValidateInput())
            {
                try
                {
                    int overtimeHours = Convert.ToInt32(txtHora.Text);
                    DateOnly startDate = DateOnly.FromDateTime(dtpFecha.Value);
                    DateOnly endDate = DateOnly.FromDateTime(dtpFechaFin.Value);

                    // Obtener o crear la nómina para el empleado y período especificado
                    var payrollCreateDto = new PayrollCreateDTO
                    {
                        EmployeeId = _selectedEmployee.Id,
                        StartDate = startDate,
                        EndDate = endDate
                    };

                    // Realizar la solicitud HTTP POST para crear la nómina
                    var createdPayrollResponse = await _apiClient.CreatePayrollAsync(payrollCreateDto, overtimeHours);

                    if (createdPayrollResponse.IsSuccessStatusCode)
                    {
                        // Obtener el ID de la nómina creada
                        var responseContent = await createdPayrollResponse.Content.ReadAsStringAsync();
                        int payrollId = int.Parse(responseContent);

                        // Mostrar mensaje de éxito si se han cargado datos
                        MessageBox.Show("Datos de nómina calculados y guardados correctamente.",
                                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Opcional: Cargar o mostrar detalles adicionales si es necesario
                        // Puedes realizar operaciones adicionales aquí si deseas mostrar detalles específicos

                        // Actualizar el DataGridView u otros controles según sea necesario
                        await RefreshPayrollDataGrid(payrollId);
                    }
                    else
                    {
                        // Manejar caso de fallo en la creación de la nómina
                        MessageBox.Show("Error al guardar los datos de la nómina. Por favor, inténtelo nuevamente.",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al calcular y guardar los datos de la nómina: {ex.Message}",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un empleado y especifique las fechas de inicio y fin del período.",
                                "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async Task RefreshPayrollDataGrid(int payrollId)
        {
            try
            {
                // Aquí deberías llamar a tu API para obtener los detalles de la nómina específica usando el payrollId
                var payrollDetails = await _apiClient.Payrolls.GetByIdAsync(payrollId);

                // Suponiendo que tienes un método o propiedad en tu formulario para mostrar los detalles en dgvNomina
                dgvNomina.DataSource = null; // Limpiar datos anteriores si es necesario
                dgvNomina.DataSource = new List<PayrollDTO> { payrollDetails }; // Usar tu DTO adecuado

                // Opcionalmente, puedes ajustar las columnas si es necesario
                dgvNomina.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar datos de nómina en el DataGridView: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrEmpty(txtHora.Text))
            {
                MessageBox.Show("Ingrese las horas trabajadas para calcular la nómina.",
                                "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (dtpFecha.Value == null || dtpFechaFin.Value == null)
            {
                MessageBox.Show("Especifique las fechas de inicio y fin del período para calcular la nómina.",
                                "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private async void btnSeleccionEmp_Click(object sender, EventArgs e)
        {
            if (dgvdEmployees.SelectedRows.Count > 0)
            {
                var selectedRow = dgvdEmployees.SelectedRows[0];
                if (selectedRow.DataBoundItem is EmployeeDTO selectedEmployee)
                {
                    _selectedEmployee = selectedEmployee;

                    // Cambiar a la segunda página del tabControl
                    tabNomina.SelectedTab = tabPage2;
                }
                else
                {
                    MessageBox.Show("No se pudo obtener el empleado seleccionado correctamente.",
                                    "Error de selección", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un empleado.",
                                "Selección de Empleado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {

        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtHora.Clear();

        }
        private void tabControl1_Click(object sender, EventArgs e)
        {



        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}
