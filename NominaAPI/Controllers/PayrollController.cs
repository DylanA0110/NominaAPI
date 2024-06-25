using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PayrollAPI.Repository;
using PayrollAPI.Repository.IRepository;
using SharedModels.Dto;
using SharedModels.Entidades;
using SharedModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayrollController : ControllerBase
    {
        private readonly IPayrollCalculationService _payrollService;
        private readonly IIncomeRepository _incomeRepository;
        private readonly IDeductionRepository _deductionRepository;
        private readonly IPayrollRepository _payrollRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<PayrollController> _logger;

        public PayrollController(
            IPayrollCalculationService payrollService,
            IIncomeRepository incomeRepository,
            IDeductionRepository deductionRepository,
            IPayrollRepository payrollRepository,
            IMapper mapper,
            ILogger<PayrollController> logger,
            IEmployeeRepository employeeRepository)
        {
            _payrollService = payrollService;
            _incomeRepository = incomeRepository;
            _deductionRepository = deductionRepository;
            _payrollRepository = payrollRepository;
            _mapper = mapper;
            _logger = logger;
            _employeeRepository = employeeRepository;
        }

        [Authorize]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<PayrollDTO>>> GetPayrolls()
        {
            try
            {
                _logger.LogInformation("Obteniendo todas las nóminas");

                var payrolls = await _payrollRepository.GetAllAsync();

                return Ok(_mapper.Map<IEnumerable<PayrollDTO>>(payrolls));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener las nóminas: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error interno del servidor al obtener las nóminas.");
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PayrollDTO>> GetPayroll(int id)
        {
            try
            {
                _logger.LogInformation($"Obteniendo nómina con ID: {id}");

                var payroll = await _payrollRepository.GetById(id);

                if (payroll == null)
                {
                    _logger.LogWarning($"No se encontró ninguna nómina con ID: {id}");
                    return NotFound("Nómina no encontrada.");
                }

                return Ok(_mapper.Map<PayrollDTO>(payroll));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener la nómina con ID {id}: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error interno del servidor al obtener la nómina.");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PayrollDTO>> PostPayroll([FromBody] PayrollCreateDTO createDto, [FromQuery] int overTimeHours)
        {
            if (createDto == null)
            {
                _logger.LogError("Se recibió una solicitud de nómina nula.");
                return BadRequest("Los datos de la nómina no pueden ser nulos.");
            }

            try
            {
                _logger.LogInformation($"Creando una nueva nómina para el empleado con ID: {createDto.EmployeeId}");

                // Verificar si el empleado existe
                var employee = await _employeeRepository.GetById(createDto.EmployeeId);
                if (employee == null)
                {
                    _logger.LogWarning($"No se encontró ningún empleado con ID: {createDto.EmployeeId}");
                    return BadRequest("Empleado no encontrado.");
                }

                // Realizar cálculo de la nómina
                var newPayroll = _payrollService.CalculatePayroll(
                    employee,
                    createDto.StartDate,
                    createDto.EndDate,
                    overTimeHours);

                // Guardar la nueva nómina
                await _payrollRepository.CreateAsync(newPayroll);

                _logger.LogInformation($"Nueva nómina creada para el empleado con ID: {createDto.EmployeeId}");

                return CreatedAtAction(nameof(GetPayroll), new { id = newPayroll.Id }, _mapper.Map<PayrollDTO>(newPayroll));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear una nueva nómina: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error interno del servidor al crear una nueva nómina.");
            }
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeletePayroll(int id)
        {
            try
            {
                _logger.LogInformation($"Eliminando nómina con ID: {id}");

                var payroll = await _payrollRepository.GetById(id);
                if (payroll == null)
                {
                    _logger.LogInformation($"No se encontró ninguna nómina con ID: {id}");
                    return NotFound("Nómina no encontrada.");
                }

                await _payrollRepository.DeleteAsync(payroll);

                _logger.LogInformation($"Nómina con ID {id} eliminada correctamente.");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar la nómina con ID {id}: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Se produjo un error al eliminar la nómina.");
            }
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PatchPayroll(int id,
            JsonPatchDocument<PayrollUpdateDTO> patchDto)
        {
            if (id <= 0)
            {
                return BadRequest("ID de nómina no válido.");
            }

            try
            {
                _logger.LogInformation($"Aplicando el parche a la nómina con ID: {id}");

                var payroll = await _payrollRepository.GetById(id);
                if (payroll == null)
                {
                    _logger.LogWarning($"No se encontró ninguna nómina con ID: {id}");
                    return NotFound("Nómina no encontrada.");
                }

                var payrollDto = _mapper.Map<PayrollUpdateDTO>(payroll);

                patchDto.ApplyTo(payrollDto, ModelState);

                if (!ModelState.IsValid)
                {
                    _logger.LogError("El parche de la nómina no es válido.");
                    return BadRequest(ModelState);
                }

                _mapper.Map(payrollDto, payroll);
                await _payrollRepository.SaveChangesAsync();

                _logger.LogInformation($"Parche aplicado correctamente a la nómina con ID: {id}");

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al aplicar el parche a la nómina con ID {id}: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error interno del servidor al aplicar el parche a la nómina.");
            }
        }
    }
}
