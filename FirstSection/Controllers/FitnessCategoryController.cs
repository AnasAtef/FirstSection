using AutoMapper;
using FirstSection.Contracts;
using FirstSection.Data;
using FirstSection.Models.FitnessCategory;
using Microsoft.AspNetCore.Mvc;

namespace FirstSection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FitnessCategoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IFitnessCategoryRepository _fitnessCategoryPlanRepository;
        public FitnessCategoryController(IFitnessCategoryRepository fitnessCategoryPlanRepository, IMapper mapper)
        {
            this._fitnessCategoryPlanRepository = fitnessCategoryPlanRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetFitnessCategory>>> GetFitnessCategories()
        {
            var fitnessCategories = await _fitnessCategoryPlanRepository.GetAllAsync();
            var records = _mapper.Map<List<GetFitnessCategory>>(fitnessCategories);
            return Ok(records);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GetFitnessCategory>> CreateFitnessCategory([FromBody] CreateFitnessCategoryDto createFitnessCategoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fitnessCategory = _mapper.Map<FitnessCategory>(createFitnessCategoryDto);
            var createdFitnessCategory = await _fitnessCategoryPlanRepository.AddAsync(fitnessCategory);
            var record = _mapper.Map<GetFitnessCategory>(createdFitnessCategory);

            return CreatedAtAction(nameof(GetFitnessCategory), new { id = record.Id }, record);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GetFitnessCategory>> GetFitnessCategory(int id)
        {
            var fitnessCategory = await _fitnessCategoryPlanRepository.GetAsync(id);
            if (fitnessCategory == null)
            {
                return NotFound();
            }

            var record = _mapper.Map<GetFitnessCategory>(fitnessCategory);
            return Ok(record);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteFitnessCategory(int id)
        {
            var fitnessCategory = await _fitnessCategoryPlanRepository.GetAsync(id);
            if (fitnessCategory == null)
            {
                return NotFound();
            }

            await _fitnessCategoryPlanRepository.DeleteAsync(id);
            return NoContent();
        }

    }
}
