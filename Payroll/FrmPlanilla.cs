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
            if (ValidateInput())
            {
                var payrollCreateDTO = new PayrollCreateDTO
                {
                    EmployeeId = _selectedEmployee.Id,
                    StartDate = DateOnly.FromDateTime(dtpFecha.Value),
                    EndDate = DateOnly.FromDateTime(dtpFechaFin.Value)
                };
                int horas = Convert.ToInt32(txtHora.Text);
                    // Crear la nómina
                    var response = await _apiClient.CreatePayrollAsync(payrollCreateDTO, horas);

                    // Verificar si el objeto response no es nulo y contiene el ID de la nómina creada
                    if (response != null && response.Id > 0)
                    {
                        // Obtener detalles de ingresos
                        var incomesResponse = await _apiClient.GetIncomesByPayrollIdAsync(response.Id);

                        // Obtener detalles de deducciones
                        var deductionsResponse = await _apiClient.GetDeductionsByPayrollIdAsync(response.Id);

                        // Limpiar el DataGridView dgvNomina si es necesario
                        dgvNomina.Rows.Clear();

                        // Agregar los ingresos al DataGridView dgvNomina
                        foreach (var income in incomesResponse)
                        {
                            dgvNomina.Rows.Add(
                                income.Id,
                                income.OrdinarySalary,
                                income.Seniority,
                                income.OccupationalRisk,
                                income.NightShift,
                                income.Overtime
                            );
                        }

                        // Agregar las deducciones al DataGridView dgvNomina
                        foreach (var deduction in deductionsResponse)
                        {
                            dgvNomina.Rows.Add(
                                deduction.Id,
                                deduction.INSS,
                                deduction.IR
                            );
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encontró la nómina creada o no se devolvió un ID válido.");
                    }
               
               
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
