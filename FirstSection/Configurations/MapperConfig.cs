using AutoMapper;
using FirstSection.Data;
using FirstSection.Models.Country;
using FirstSection.Models.Hotel;
using FirstSection.Models.Users;
namespace FirstSection.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Country, CreateCountryDto>().ReverseMap();
            CreateMap<Country, GetCountryDto>().ReverseMap();
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Hotel, HotelDto>().ReverseMap();
            CreateMap<Country, UpdateCountryDto>().ReverseMap();
            CreateMap < Hotel, CreateHotelDto>().ReverseMap();
            CreateMap<ApiUserDto, APIUser>().ReverseMap();


        }
    }
}
