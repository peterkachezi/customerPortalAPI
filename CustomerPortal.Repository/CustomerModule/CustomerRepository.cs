

using AutoMapper;
using CustomerPortal.DAL.ContextContext;
using CustomerPortal.DAL.Model;
using CustomerPortal.DTO.CountryModule;
using CustomerPortal.DTO.CustomerModule;
using Microsoft.EntityFrameworkCore;

namespace CustomerPortal.Repository.CustomerModule
{
    public  class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext context;

        private readonly IMapper mapper;
        public CustomerRepository(IMapper mapper, ApplicationDbContext context)
        {
            this.context = context;

            this.mapper = mapper;
        }

        public async Task<CustomerDTO> Create(CustomerDTO customerDTO)
        {
            try
            {
                var data = mapper.Map<Customer>(customerDTO);

                context.Customers.Add(data);

                await context.SaveChangesAsync();

                return customerDTO;
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

                var customer = await context.Customers.FindAsync(Id);

                if (customer != null)
                {
                    context.Customers.Remove(customer);

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
        public async Task<List<CustomerDTO>> GetAll()
        {
            try
            {
                var data = await context.Customers.ToListAsync();

                var countries = mapper.Map<List<CustomerDTO>>(data);

                return countries;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }

        }



    }
}
