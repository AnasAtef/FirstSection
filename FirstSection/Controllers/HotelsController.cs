using AutoMapper;
using FirstSection.Contracts;
using FirstSection.Data;
using FirstSection.Models.Hotel;
using FirstSection.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class HotelsController : ControllerBase
{
    
    private readonly IHotelRepository _hotelRepository;
    private readonly IMapper _mapper;

    public HotelsController( IHotelRepository hotelRepository,IMapper mapper)
    {
        
        this._hotelRepository = hotelRepository;
        this._mapper = mapper;
    }

    // GET: api/Hotels
    [HttpGet]
    public async Task<ActionResult<IEnumerable<HotelDto>>> GetHotels()
    {
        var hotels = await _hotelRepository.GetAllAsync();
        return _mapper.Map<List<HotelDto>>(hotels); 
         
    }

    // GET: api/Hotels/5
    [HttpGet("{id}")]
    public async Task<ActionResult<HotelDto>> GetHotel(int id)
    {
        var hotel = await _hotelRepository.GetAsync(id);

        if (hotel == null)
        {
            return NotFound();
        }

        return Ok(_mapper.Map<HotelDto>(hotel)); 
    }

    // POST: api/Hotels
    [HttpPost]
    public async Task<ActionResult<Hotel>> PostHotel(CreateHotelDto hoteldto)
    {
        var hotel=_mapper.Map<Hotel>(hoteldto);
        await _hotelRepository.AddAsync(hotel);
        

        return CreatedAtAction(nameof(GetHotel), new { id = hotel.Id }, hotel);
    }

    // PUT: api/Hotels/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateHotel(int id, HotelDto hoteldto)
    {
        if (id != hoteldto.Id)
        {
            return BadRequest();
        }
        var hotel = await _hotelRepository.GetAsync(id);
        if (hotel == null)
        {
            return NotFound();
        }
        _mapper .Map(hoteldto,hotel);

        try
        {
            await _hotelRepository.UpdateAsync(hotel);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await HotelExists(id))
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

    // DELETE: api/Hotels/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteHotel(int id)
    {
        var hotel = await _hotelRepository.GetAsync(id);
        if (hotel == null)
        {
            return NotFound();
        }

        await _hotelRepository.DeleteAsync(id);

        return NoContent();
    }

    private async Task<bool> HotelExists(int id)
    {
        return await _hotelRepository.Exists(id);
    }
}
