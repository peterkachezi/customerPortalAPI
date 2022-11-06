using CustomerPortal.DTO.CountryModule;
using CustomerPortal.Repository.CountryModule;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryRepository countryRepository;
        public CountriesController(ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCountries()
        {
            try
            {
                var countries = await countryRepository.GetAll();

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
        public async Task<IActionResult> Post([FromBody] CountryDTO countryDTO)
        {
            try
            {
                bool isDependantExist = await countryRepository.CheckIfMemberExist(countryDTO);

                if (isDependantExist == false)
                {
                    var result = await countryRepository.Create(countryDTO);

                    if (result != null)
                    {
                        return Ok("Country has been successfully created");
                    }
                    else
                    {
                        return BadRequest($"Failed to create request");

                    }
                }
                return BadRequest($"Country exits");

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
            var delete = await countryRepository.Delete(Id);

            if (delete == true)
            {
                return Ok("Country has been successfully deleted");
            }
            return BadRequest($"Something went wrong");


        }
    }
}
