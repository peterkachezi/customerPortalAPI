

using AutoMapper;
using CustomerPortal.DAL.ContextContext;
using CustomerPortal.DAL.Model;
using CustomerPortal.DTO.CountryModule;
using Microsoft.EntityFrameworkCore;

namespace CustomerPortal.Repository.CountryModule
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext context;

        private readonly IMapper mapper;
        public CountryRepository(IMapper mapper, ApplicationDbContext context)
        {
            this.context = context;

            this.mapper = mapper;
        }
        public async Task<CountryDTO> Create(CountryDTO countryDTO)
        {
            try
            {
                var data = mapper.Map<Country>(countryDTO);

                context.Countries.Add(data);

                await context.SaveChangesAsync();

                return countryDTO;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }
        public async Task<bool> Delete(int Id)
        {
            try
            {
                bool result = false;

                var country = await context.Countries.FindAsync(Id);

                if (country != null)
                {
                    context.Countries.Remove(country);

                    await context.SaveChangesAsync();

                    result = true;
                }

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }
        public async Task<List<CountryDTO>> GetAll()
        {
            try
            {
                var data = await context.Countries.ToListAsync();

                var countries = mapper.Map<List<CountryDTO>>(data);

                return countries;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }

        }
        public async Task<bool> CheckIfMemberExist(CountryDTO countryDTO)
        {
            try
            {
                bool result = await context.Countries.AnyAsync(p => p.CountryName == countryDTO.CountryName);

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }
        }
    }
}
