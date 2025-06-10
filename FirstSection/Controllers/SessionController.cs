using AutoMapper;
using FirstSection.Contracts;
using FirstSection.Data;
using FirstSection.Models.Session;
using Microsoft.AspNetCore.Mvc;

namespace FirstSection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly ISessionRepository _sessionRepository;
        private readonly IMapper _mapper;

        public SessionController(ISessionRepository sessionRepository, IMapper mapper)
        {
            _sessionRepository = sessionRepository;
            _mapper = mapper;
        }



        [HttpPost]
        public async Task<ActionResult<GetSessionDto>> PostSession(CreateSessionDto createSessionDto)
        {
            try
            {
                var session = _mapper.Map<Session>(createSessionDto);
                var addedSession = await _sessionRepository.AddAsync(session);
                return StatusCode(201, _mapper.Map<GetSessionDto>(addedSession));

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetSessionDto>>> GetSessions()
        {
            try
            {
                var sessions = await _sessionRepository.GetAllAsync();
                return Ok(_mapper.Map<IEnumerable<GetSessionDto>>(sessions));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
