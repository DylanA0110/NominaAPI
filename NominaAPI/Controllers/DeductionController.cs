using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PayrollAPI.Repository.IRepository;
using SharedModels.Dto;
using SharedModels.Entidades;

namespace PayrollAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeductionController : ControllerBase
    {
        private readonly IDeductionRepository _deductionRepo;
        private readonly ILogger<DeductionController> _logger;
        private readonly IMapper _mapper;

        public DeductionController(IDeductionRepository deductionRepo, ILogger<DeductionController> logger, IMapper mapper)
        {
            _deductionRepo = deductionRepo;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<DeductionDTO>>> GetDeductions()
        {
            try
            {
                _logger.LogInformation("Getting all deductions");

                var deductions = await _deductionRepo.GetAllAsync();
                return Ok(_mapper.Map<IEnumerable<DeductionDTO>>(deductions));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting deductions: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpGet("{id:int}", Name = "GetDeduction")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DeductionDTO>> GetDeduction(int id)
        {
            try
            {
                _logger.LogInformation($"Getting deduction with ID: {id}");

                var deduction = await _deductionRepo.GetById(id);

                if (deduction == null)
                {
                    _logger.LogWarning($"Deduction with ID {id} not found");
                    return NotFound();
                }

                return Ok(_mapper.Map<DeductionDTO>(deduction));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting deduction with ID {id}: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DeductionDTO>> CreateDeduction([FromBody] DeductionCreateDTO createDto)
        {
            if (createDto == null)
            {
                _logger.LogError("Deduction creation failed due to empty request body");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Deduction creation failed due to invalid model state");
                return BadRequest(ModelState);
            }

            try
            {
                _logger.LogInformation("Creating a new deduction");

                var deduction = _mapper.Map<Deduction>(createDto);
                await _deductionRepo.CreateAsync(deduction);

                return CreatedAtRoute("GetDeduction", new { id = deduction.Id }, _mapper.Map<DeductionDTO>(deduction));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating deduction: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateDeduction(int id, [FromBody] DeductionUpdateDTO updateDto)
        {
            if (updateDto == null || id != updateDto.Id)
            {
                _logger.LogError("Deduction update failed due to invalid request body or ID mismatch");
                return BadRequest(ModelState);
            }

            try
            {
                var deduction = await _deductionRepo.GetById(id);
                if (deduction == null)
                {
                    _logger.LogWarning($"Deduction with ID {id} not found");
                    return NotFound();
                }

                _mapper.Map(updateDto, deduction);
                await _deductionRepo.UpdateAsync(deduction);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating deduction: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteDeduction(int id)
        {
            try
            {
                var deduction = await _deductionRepo.GetById(id);
                if (deduction == null)
                {
                    _logger.LogWarning($"Deduction with ID {id} not found");
                    return NotFound();
                }

                await _deductionRepo.DeleteAsync(deduction);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting deduction: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
    }
}
