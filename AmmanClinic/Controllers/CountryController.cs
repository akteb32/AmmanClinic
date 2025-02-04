using AmmanClinic.Models;
using AmmanClinic.Services;
using AmmanClinic.data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AmmanClinic.Controllers
{

    [Authorize(Roles = "admin")]
    public class CountryController : Controller
    {
        ICountryService countryService;
        public CountryController(ICountryService _c)
        {
            countryService = _c;
        }

        public IActionResult Index()
        {
            return View("NewCountry");
        }

        public IActionResult Save(CountryDTO countryDTO)
        {


            countryService.Insert(countryDTO);


            return View("NewCountry");
        }

        public IActionResult CountryList()
        {


            List<CountryDTO> countries = countryService.GetAll();


            return View("CountryList", countries);
        }

        public IActionResult Delete(int Id)
        {

            countryService.Delete(Id);

            List<CountryDTO> countries = countryService.GetAll();

            return View("CountryList", countries);
        }
    }
}
