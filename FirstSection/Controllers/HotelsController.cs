using FirstSection.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FirstSection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private static List<Hotel> hotels = new List <Hotel>
        {
            new Hotel{Id=1,Name="Grand Plaza", Address ="123 Main St", Rating= 4.5},
            new Hotel{Id=2,Name="Ocean View", Address ="456 Beach Rd", Rating= 4}

        };
        // GET: api/<HotelsController>
        [HttpGet]
        public ActionResult<IEnumerable<Hotel>> Get()
        {
            return  Ok(hotels);
        }

        // GET api/<HotelsController>/5
        [HttpGet("{id}")]
        public ActionResult<Hotel> Get(int id)
        {
            var hotel = hotels.FirstOrDefault(h=> h.Id==id);
            if (hotel == null) 
            {
            return NotFound();
            }
            return Ok(hotel);
        }

        // POST api/<HotelsController>
        [HttpPost]
        public ActionResult<Hotel> Post([FromBody] Hotel newHotel)
        {
            if (hotels.Any(h => h.Id == newHotel.Id))
            { 
            return BadRequest("Hotel with this id already exists");
            }
            hotels.Add(newHotel);
            return CreatedAtAction(nameof(Get), new { id = newHotel.Id }, newHotel);
        }

        // PUT api/<HotelsController>/5
        [HttpPut("{id}")]
        public ActionResult<Hotel> Put(int id, [FromBody] Hotel updateHotel)
        {
            var existinghotel =hotels.FirstOrDefault(h => h.Id==id);
            if (existinghotel==null) 
            {
                return NotFound();
            }
            existinghotel.Id = updateHotel.Id;
            existinghotel.Address = updateHotel.Address;
            existinghotel.Rating = updateHotel.Rating;
            return NoContent();

        }

        // DELETE api/<HotelsController>/5
        [HttpDelete("{id}")]
        public ActionResult<Hotel> Delete(int id)

        {
            var existing2hotel= hotels.FirstOrDefault(h => h.Id==id);
            if (existing2hotel == null) 
            {
                return NotFound(new { message = "Hotel not found or does not exist"});
            }
             hotels.Remove(existing2hotel);
            return NoContent();


        }
    }
}
