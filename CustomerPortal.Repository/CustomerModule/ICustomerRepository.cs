using CustomerPortal.DTO.CountryModule;
using CustomerPortal.DTO.CustomerModule;

namespace CustomerPortal.Repository.CustomerModule
{
    public interface ICustomerRepository
    {
        Task<CustomerDTO> Create(CustomerDTO customerDTO);
        Task<bool> Delete(int Id);
        Task<List<CustomerDTO>> GetAll();
        Task<bool> CheckIfMemberExist(CustomerDTO customerDTO);

    }
}