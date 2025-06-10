using AutoMapper;
using FirstSection.Contracts;
using FirstSection.Data;
using FirstSection.Models.Training;
using Microsoft.AspNetCore.Mvc;

namespace FirstSection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITrainingRepository _trainingRepository;

        public TrainingController(ITrainingRepository trainingRepository, IMapper mapper)
        {
            _trainingRepository = trainingRepository;
            _mapper = mapper;
        }

        // GET: api/Training
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetTrainingDto>>> GetTrainings()
        {
            try
            {
                var trainings = await _trainingRepository.GetAllAsync();
                var trainingDtos = _mapper.Map<List<GetTrainingDto>>(trainings);
                return Ok(trainingDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/Training/{id}
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GetTrainingDto>> GetTraining(Guid id)
        {
            try
            {
                var training = await _trainingRepository.GetAsync(id);

                if (training == null)
                {
                    return NotFound($"Training with ID {id} not found.");
                }

                var trainingDto = _mapper.Map<GetTrainingDto>(training);
                return Ok(trainingDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        // POST: api/Training
        [HttpPost]
        public async Task<ActionResult<GetTrainingDto>> CreateTraining(CreateTrainingDto createTrainingDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var training = _mapper.Map<Training>(createTrainingDto);
                training.Id = Guid.NewGuid(); // Generate new ID

                var createdTraining = await _trainingRepository.AddAsync(training);
                var trainingDto = _mapper.Map<GetTrainingDto>(createdTraining);

                return CreatedAtAction(
                    nameof(GetTraining),
                    new { id = trainingDto.Id },
                    trainingDto
                );
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

      

        // DELETE: api/Training/{id}
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteTraining(Guid id)
        {
            try
            {
                var training = await _trainingRepository.GetAsync(id);

                if (training == null)
                {
                    return NotFound($"Training with ID {id} not found.");
                }

                await _trainingRepository.DeleteAsync(id);
                return NoContent(); // 204 No Content - successful deletion
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("getTrainingsForFitnessCategory")]
        public async Task<ActionResult<IEnumerable<GetTrainingDto>>> GetTrainingsForFitnessCategory(int id)
        {
            try
            {
                var trainings = await _trainingRepository.GetTrainingForFintnessCategory(id);

                if (trainings == null)
                {
                    return NotFound($"Trainings with Fitness Category ID {id} not found.");
                }

                var trainingDtos = _mapper.Map<IEnumerable<GetTrainingDto>>(trainings);
                return Ok(trainingDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }

    }
}