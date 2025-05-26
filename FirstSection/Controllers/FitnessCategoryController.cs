using AutoMapper;
using FirstSection.Contracts;
using FirstSection.Models.Country;
using FirstSection.Models.FitnessCategory;
using FirstSection.Repository;
using Microsoft.AspNetCore.Http;
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


    }
}
