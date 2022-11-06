
using AutoMapper;
using CustomerPortal.DAL.Model;
using CustomerPortal.DTO.CountryModule;
using CustomerPortal.DTO.CustomerModule;

namespace CustomerPortal.Repository.Automapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();

            CreateMap<Country, CountryDTO>().ReverseMap();
        }
    }
}
