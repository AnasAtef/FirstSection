using AutoMapper;
using FirstSection.Contracts;
using FirstSection.Data;
using FirstSection.Models.Country;
using FirstSection.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstSection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserFitnessPlanController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUserFitnessPlanRepository _userFitnessPlanRepository;
        public UserFitnessPlanController(IUserFitnessPlanRepository userFitnessPlanRepository)
        {
            this._userFitnessPlanRepository = userFitnessPlanRepository;
        }

        // GET: api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetCountryDto>>> GetCountries()
        {
            var countries = await _userFitnessPlanRepository.GetAllAsync();
            var records = mapper.Map<List<GetCountryDto>>(countries);
            return Ok(records);
        }

        // GET: api/Countries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDto>> GetCountry(int id)
        {
            var country = await _userFitnessPlanRepository.GetAsync(id);


            if (country == null)
            {
                return NotFound();
            }
            var record = mapper.Map<CountryDto>(country);
            return Ok(country);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountry(int id, UpdateCountryDto updatecountrydto)
        {
            if (id != updatecountrydto.Id)
            {
                return BadRequest();
            }

            //_context.Entry(updatecountrydto).State = EntityState.Modified;
            var country = await _userFitnessPlanRepository.GetAsync(id);
            if (country == null)
            {
                return NotFound();
            }

            mapper.Map(updatecountrydto, country);

            try
            {
                await _userFitnessPlanRepository.UpdateAsync(country);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CountryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

     

        // DELETE: api/Countries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            var country = _userFitnessPlanRepository.GetAsync(id);
            if (country == null)
            {
                return NotFound();
            }
            await _userFitnessPlanRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> CountryExists(int id)
        {
            return await _userFitnessPlanRepository.Exists(id);
        }

    }
}
