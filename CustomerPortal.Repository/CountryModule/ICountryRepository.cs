using CustomerPortal.DTO.CountryModule;

namespace CustomerPortal.Repository.CountryModule
{
    public interface ICountryRepository
    {
        Task<bool> CheckIfMemberExist(CountryDTO countryDTO);
        Task<CountryDTO>Create(CountryDTO countryDTO);
        Task<bool> Delete(int Id);
        Task<List<CountryDTO>>GetAll();
    }
}