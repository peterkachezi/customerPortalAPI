using CustomerPortal.DTO.CountryModule;
using CustomerPortal.DTO.CustomerModule;
using CustomerPortal.Helper;
using CustomerPortal.Repository.CountryModule;
using CustomerPortal.Repository.CustomerModule;
using Microsoft.AspNetCore.Mvc;


namespace CustomerPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository customerRepository;
        public CustomersController(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCountries()
        {
            try
            {
                var countries = await customerRepository.GetAll();

                if (countries == null)
                {
                    return NotFound();
                }
                if (countries != null)
                {
                    return Ok(countries);
                }
                return BadRequest($"Something went wrong");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return BadRequest($"Something went wrong");
            }
        }

        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomerDTO customerDTO)
        {
            try
            {
                bool isDependantExist = await customerRepository.CheckIfMemberExist(customerDTO);

                if (isDependantExist == false)
                {
                    var result = await customerRepository.Create(customerDTO);

                    if (result != null)
                    {
                        return Ok("Country has been successfully created");
                    }
                    else
                    {
                        return BadRequest($"Failed to create request");

                    }
                }
                return BadRequest($"Something went wrong");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return BadRequest($"Something went wrong");

            }
        }


        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> Delete(int Id)

        {
            var delete = await customerRepository.Delete(Id);

            if (delete == true)
            {
                return Ok("Country has been successfully deleted");
            }
            return BadRequest($"Something went wrong");


        }


        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> UploadFileAsync([FromForm] CustomerDTO customerDTO)
        {

            try
            {

                if (customerDTO.file.Length > 0)
                {
                    using (var ms = new MemoryStream())
                    {
                        customerDTO.file.CopyTo(ms);

                        var fileBytes = ms.ToArray();

                        customerDTO.CustomerPhoto = fileBytes;
                    }

                    var result = await customerRepository.Create(customerDTO);

                    if (result != null)
                    {
                        return Ok("Customer has been successfully created");
                    }

                    return BadRequest($"Unable to create customer");
                }

                return BadRequest($"Something went wrong");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }

        }




    }
}
