using FirstSection.Models.Hotel;

namespace FirstSection.Models.Country
{
    public class CountryDto : BaseCountryDto
    {
        public int CountryId { get; set; }
        

        public List<HotelDto> Hotels { get; set; }
    }

}
