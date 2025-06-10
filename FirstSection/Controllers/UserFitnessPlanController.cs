using AutoMapper;
using FirstSection.Contracts;
using FirstSection.Data;
using FirstSection.Models.UserFitnessPlan;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FirstSection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User")]
    public class UserFitnessPlanController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserFitnessPlanRepository _userFitnessPlanRepository;
        public UserFitnessPlanController(IUserFitnessPlanRepository userFitnessPlanRepository, IMapper mapper)
        {
            this._userFitnessPlanRepository = userFitnessPlanRepository;
            this._mapper = mapper;
        }


        [HttpPost]
        public async Task<ActionResult<GetUserFitnessPlanDto>> CreateUserFitnessPlan(CreateUserFitnessPlanDto createUserFitnessPlanDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var userFitnessPlan = _mapper.Map<UserFitnessPlan>(createUserFitnessPlanDto);
                userFitnessPlan.Id = Guid.NewGuid();
                var createdUserFitnessPlan = await _userFitnessPlanRepository.AddAsync(userFitnessPlan);
                return StatusCode(201, _mapper.Map<GetUserFitnessPlanDto>(createdUserFitnessPlan));
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }

        [HttpGet("GetUserFitnessPlans")]
      
        public async Task<ActionResult<IEnumerable<GetUserFitnessPlanDto>>> GetUserFitnessPlans()
        {
            try
            {
                // Try multiple claim types to get the user ID
                var currentUserId = GetCurrentUserId();

                if (string.IsNullOrEmpty(currentUserId))
                {
                    return Unauthorized("User not authenticated or invalid user ID");
                }

                if (!Guid.TryParse(currentUserId, out var userId))
                {
                    return BadRequest("Invalid user ID format");
                }

                // Fetch user fitness plans with related data
                var userFitnessPlans = await _userFitnessPlanRepository.GetUserFitnessPlansAsync(userId);

                // Map to DTOs using AutoMapper
                var userFitnessPlanDtos = _mapper.Map<IEnumerable<GetUserFitnessPlanDto>>(userFitnessPlans);

                return Ok(userFitnessPlanDtos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while retrieving fitness plans");
            }
        }

        private string? GetCurrentUserId()
        {
            // Try different claim types that might contain the user ID
            var userIdClaims = new[]
            {
                "nameid",                    // Your JWT uses this
                ClaimTypes.NameIdentifier,   // Standard claim type
                "sub",                       // Standard JWT subject claim
                "userId",                    // Custom claim
                "id"                         // Another possible custom claim
            };

            foreach (var claimType in userIdClaims)
            {
                var claim = User.FindFirst(claimType);
                if (claim != null && !string.IsNullOrEmpty(claim.Value))
                {
                    return claim.Value;
                }
            }

            return null;
        }


    }
}
