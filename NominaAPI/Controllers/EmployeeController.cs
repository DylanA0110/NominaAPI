using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PayrollAPI.Repository.IRepository;
using SharedModels.Dto;
using SharedModels.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(
            IEmployeeRepository employeeRepository,
            IMapper mapper,
            ILogger<EmployeeController> logger)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _logger = logger;
        }

        [Authorize]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetEmployees()
        {
            try
            {
                _logger.LogInformation("Obteniendo todos los empleados");

                var employees = await _employeeRepository.GetAllAsync();

                return Ok(_mapper.Map<IEnumerable<EmployeeDTO>>(employees));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener los empleados: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error interno del servidor al obtener los empleados.");
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<EmployeeDTO>> GetEmployee(int id)
        {
            try
            {
                _logger.LogInformation($"Obteniendo empleado con ID: {id}");

                var employee = await _employeeRepository.GetById(id);

                if (employee == null)
                {
                    _logger.LogWarning($"No se encontró ningún empleado con ID: {id}");
                    return NotFound("Empleado no encontrado.");
                }

                return Ok(_mapper.Map<EmployeeDTO>(employee));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener el empleado con ID {id}: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error interno del servidor al obtener el empleado.");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<EmployeeDTO>> PostEmployee([FromBody] EmployeeCreateDTO createDto)
        {
            if (createDto == null)
            {
                _logger.LogError("Se recibió una solicitud de empleado nula.");
                return BadRequest("Los datos del empleado no pueden ser nulos.");
            }

            try
            {
                _logger.LogInformation($"Creando un nuevo empleado con nombre: {createDto.FirstName} {createDto.LastName}");

                // Verificar si el empleado ya existe
                var existingEmployee = await _employeeRepository
                    .GetAsync(e => e.IdentificationNumber == createDto.IdentificationNumber);

                if (existingEmployee != null)
                {
                    _logger.LogWarning($"El empleado con identificación '{createDto.IdentificationNumber}' ya existe.");
                    ModelState.AddModelError("IdentificationNumberExists", "¡El empleado con esa identificación ya existe!");
                    return BadRequest(ModelState);
                }

                var newEmployee = _mapper.Map<Employee>(createDto);

                await _employeeRepository.CreateAsync(newEmployee);

                _logger.LogInformation($"Nuevo empleado '{createDto.FirstName} {createDto.LastName}' creado con ID: {newEmployee.Id}");

                return CreatedAtAction(nameof(GetEmployee), new { id = newEmployee.Id }, _mapper.Map<EmployeeDTO>(newEmployee));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear un nuevo empleado: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error interno del servidor al crear un nuevo empleado.");
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PutEmployee(int id, EmployeeUpdateDTO updateDto)
        {
            if (updateDto == null || id != updateDto.Id)
            {
                return BadRequest("Los datos de entrada no son válidos o el ID del empleado no coincide.");
            }

            try
            {
                _logger.LogInformation($"Actualizando empleado con ID: {id}");

                var existingEmployee = await _employeeRepository.GetById(id);
                if (existingEmployee == null)
                {
                    _logger.LogInformation($"No se encontró ningún empleado con ID: {id}");
                    return NotFound("Empleado no encontrado.");
                }

                _mapper.Map(updateDto, existingEmployee);

                await _employeeRepository.SaveChangesAsync();

                _logger.LogInformation($"Empleado con ID {id} actualizado correctamente.");

                return NoContent();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!await _employeeRepository.ExistsAsync(e => e.Id == id))
                {
                    _logger.LogWarning($"No se encontró ningún empleado con ID: {id}");
                    return NotFound();
                }
                else
                {
                    _logger.LogError($"Error de concurrencia al actualizar el empleado con ID: {id}. Detalles: {ex.Message}");
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        "Error interno del servidor al actualizar el empleado.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar el empleado con ID {id}: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error interno del servidor al actualizar el empleado.");
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                _logger.LogInformation($"Eliminando empleado con ID: {id}");

                var employee = await _employeeRepository.GetById(id);
                if (employee == null)
                {
                    _logger.LogInformation($"No se encontró ningún empleado con ID: {id}");
                    return NotFound("Empleado no encontrado.");
                }

                await _employeeRepository.DeleteAsync(employee);

                _logger.LogInformation($"Empleado con ID {id} eliminado correctamente.");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar el empleado con ID {id}: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Se produjo un error al eliminar el empleado.");
            }
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PatchEmployee(int id, [FromBody] JsonPatchDocument<EmployeeUpdateDTO> patchDoc)
        {
            if (patchDoc == null || id <= 0)
            {
                return BadRequest("ID de empleado no válido o parche nulo.");
            }

            try
            {
                _logger.LogInformation($"Aplicando el parche al empleado con ID: {id}");

                var employee = await _employeeRepository.GetById(id);
                if (employee == null)
                {
                    _logger.LogWarning($"No se encontró ningún empleado con ID: {id}");
                    return NotFound("Empleado no encontrado.");
                }

                var employeeDto = _mapper.Map<EmployeeUpdateDTO>(employee);

                patchDoc.ApplyTo(employeeDto, ModelState);

                if (!ModelState.IsValid)
                {
                    _logger.LogError("El modelo de empleado después de aplicar el parche no es válido.");
                    return BadRequest(ModelState);
                }

                _mapper.Map(employeeDto, employee);
                await _employeeRepository.SaveChangesAsync();

                _logger.LogInformation($"Parche aplicado correctamente al empleado con ID: {id}");

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al aplicar el parche al empleado con ID {id}: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error interno del servidor al aplicar el parche al empleado.");
            }
        }

        [HttpGet("search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> SearchEmployees([FromQuery] string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return BadRequest("El término de búsqueda no puede estar vacío.");
            }

            try
            {
                _logger.LogInformation($"Buscando empleados con el término: {searchTerm}");

                var employees = await _employeeRepository.SearchEmployeesAsync(searchTerm);

                return Ok(_mapper.Map<IEnumerable<EmployeeDTO>>(employees));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al buscar empleados con el término {searchTerm}: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error interno del servidor al buscar empleados.");
            }
        }
    }
}
