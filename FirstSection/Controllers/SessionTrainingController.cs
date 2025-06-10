using AutoMapper;
using FirstSection.Contracts;
using FirstSection.Data;
using FirstSection.Models.Session;
using FirstSection.Models.SessionTraining;
using FirstSection.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FirstSection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionTrainingController : ControllerBase
    {
        private readonly ISessionTrainingRepository _sessionTrainingRepository;
        private readonly IMapper _mapper;

        public SessionTrainingController(ISessionTrainingRepository sessionTrainingRepository, IMapper mapper)
        {
            _sessionTrainingRepository = sessionTrainingRepository;
            _mapper = mapper;
        }



        [HttpPost]
        public async Task<ActionResult<GetSessionTraining>> PostSession(CreateSessionTrainingDto createSessionTrainingDto)
        {
            try
            {
                var sessionTraining = _mapper.Map<SessionTraining>(createSessionTrainingDto);
                await _sessionTrainingRepository.AddAsync(sessionTraining);
                return StatusCode(201, _mapper.Map<GetSessionTraining>(sessionTraining));

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<IEnumerable<GetSessionDto>>> GetSessionsTraining(Guid Id)
        {
            try
            {
                var sessionsTraining = await _sessionTrainingRepository.GetSessionTrainingGetAll(Id);
                return Ok(_mapper.Map<IEnumerable<GetSessionDto>>(sessionsTraining));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
