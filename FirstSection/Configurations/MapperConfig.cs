using AutoMapper;
using FirstSection.Data;
using FirstSection.Models.Country;
using FirstSection.Models.FitnessCategory;
using FirstSection.Models.Hotel;
using FirstSection.Models.Session;
using FirstSection.Models.SessionTraining;
using FirstSection.Models.Training;
using FirstSection.Models.UserFitnessPlan;
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
            CreateMap<Hotel, CreateHotelDto>().ReverseMap();
            CreateMap<ApiUserDto, APIUser>().ReverseMap();
            CreateMap<CreateFitnessCategoryDto, FitnessCategory>().ReverseMap();
            CreateMap<UpdateFitnessCategoryDto, FitnessCategory>().ReverseMap();
            CreateMap<GetFitnessCategory, FitnessCategory>().ReverseMap();
            CreateMap<CreateTrainingDto, Training>().ReverseMap();
            CreateMap<GetTrainingDto, Training>().ReverseMap();

            CreateMap<CreateUserFitnessPlanDto, UserFitnessPlan>().ReverseMap();

            CreateMap<UserFitnessPlan, GetUserFitnessPlanDto>()
                 .ForMember(dest => dest.TrainingName, opt => opt.MapFrom(src => src.Training.Name))
                 .ForMember(dest => dest.NumberOfDays, opt => opt.MapFrom(src => src.Training.NumberOfDays))
                 .ForMember(dest => dest.FitnessCategoryName, opt => opt.MapFrom(src => src.Training.FitnessCategory.Name));

            CreateMap<GetUserFitnessPlanDto, UserFitnessPlan>()
                .ForMember(dest => dest.Training, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore());

            CreateMap<SessionTraining, CreateSessionDto>().ReverseMap();
            CreateMap<SessionTraining, CreateSessionTrainingDto>().ReverseMap();
            CreateMap<GetSessionDto, Session>().ReverseMap();
            CreateMap<CreateSessionDto, Session>().ReverseMap();
            CreateMap<GetSessionTraining, SessionTraining>().ReverseMap();
        }
    }
}
