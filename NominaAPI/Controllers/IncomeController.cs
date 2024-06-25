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
    public class IncomeController : ControllerBase
    {
        private readonly IIncomeRepository _incomeRepo;
        private readonly ILogger<IncomeController> _logger;
        private readonly IMapper _mapper;

        public IncomeController(IIncomeRepository incomeRepo, ILogger<IncomeController> logger, IMapper mapper)
        {
            _incomeRepo = incomeRepo;
            _logger = logger;
            _mapper = mapper;
        }

        [Authorize]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<IncomeDTO>>> GetIncomes()
        {
            try
            {
                _logger.LogInformation("Getting all incomes");

                var incomes = await _incomeRepo.GetAllAsync();
                return Ok(_mapper.Map<IEnumerable<IncomeDTO>>(incomes));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting incomes: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpGet("{id:int}", Name = "GetIncome")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IncomeDTO>> GetIncome(int id)
        {
            try
            {
                _logger.LogInformation($"Getting income with ID: {id}");

                var income = await _incomeRepo.GetById(id);

                if (income == null)
                {
                    _logger.LogWarning($"Income with ID {id} not found");
                    return NotFound();
                }

                return Ok(_mapper.Map<IncomeDTO>(income));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error getting income with ID {id}: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IncomeDTO>> CreateIncome([FromBody] IncomeCreateDTO createDto)
        {
            if (createDto == null)
            {
                _logger.LogError("Income creation failed due to empty request body");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                _logger.LogError("Income creation failed due to invalid model state");
                return BadRequest(ModelState);
            }

            try
            {
                _logger.LogInformation("Creating a new income");

                var income = _mapper.Map<Income>(createDto);
                await _incomeRepo.CreateAsync(income);

                return CreatedAtRoute("GetIncome", new { id = income.Id }, _mapper.Map<IncomeDTO>(income));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating income: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateIncome(int id, [FromBody] IncomeUpdateDTO updateDto)
        {
            if (updateDto == null || id != updateDto.Id)
            {
                _logger.LogError("Income update failed due to invalid request body or ID mismatch");
                return BadRequest(ModelState);
            }

            try
            {
                var income = await _incomeRepo.GetById(id);
                if (income == null)
                {
                    _logger.LogWarning($"Income with ID {id} not found");
                    return NotFound();
                }

                _mapper.Map(updateDto, income);
                await _incomeRepo.UpdateAsync(income);

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating income: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteIncome(int id)
        {
            try
            {
                var income = await _incomeRepo.GetById(id);
                if (income == null)
                {
                    _logger.LogWarning($"Income with ID {id} not found");
                    return NotFound();
                }

                await _incomeRepo.DeleteAsync(income);
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting income: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }
    }
}
