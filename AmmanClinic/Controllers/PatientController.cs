using AmmanClinic.Models;
using AmmanClinic.Services;
using AmmanClinic.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace AmmanClinic.Controllers
{
    [Authorize(Roles = "Doctor")]
    public class PatientController : Controller
    {
        ICountryService countryService;
        IPatientService patientService;
        IConfiguration config;

        public PatientController(ICountryService _c, IPatientService _p, IConfiguration _config)
        {
            countryService = _c;
            patientService = _p;
            config = _config;
        }

        public IActionResult Index()
        {
            ViewData["IsEdit"] = false;
            List<CountryDTO> countries = countryService.GetAll();

            vmPatient vm = new vmPatient();
            vm.liCountry = countries;

            return View("NewPatient", vm);
        }

        public IActionResult Save(vmPatient vm)
        {
            //bytes
            //GUID
            string fileName = Guid.NewGuid().ToString() + "." + vm.Patient.Image.FileName.Split('.')[1];
            vm.Patient.Image.CopyTo(new FileStream(Directory.GetCurrentDirectory() + @"\wwwroot\" + config["ImageForlderName"] + @"\" + fileName, FileMode.Create));
            vm.Patient.ProfileName = fileName;
            patientService.Insert(vm.Patient);

            List<CountryDTO> countries = countryService.GetAll();

            vm.liCountry = countries;

            ViewData["IsEdit"] = true;
            return View("NewPatient", vm);
        }

        public IActionResult PatientList()
        {
            List<PatientDTO> patients = new List<PatientDTO>();
            patients = patientService.GetAll();
            return View("PatientList", patients);
        }

        public IActionResult Search()
        {
            string Name = Request.Form["txtFirstName"];

            List<PatientDTO> patients = patientService.GetByName(Name);

            return View("PatientList", patients);
        }


        public IActionResult Edit(int Id)
        {
            ViewData["IsEdit"] = true;
            vmPatient vm = new vmPatient();

            PatientDTO patientDTO = patientService.Load(Id);
            vm.Patient = patientDTO;
            vm.liCountry = countryService.GetAll();

            return View("NewPatient", vm);
        }

        public IActionResult Update(vmPatient vm)
        {
            if (vm.Patient.Image != null)
            {
                string fileName = Guid.NewGuid().ToString() + "." + vm.Patient.Image.FileName.Split('.')[1];
                vm.Patient.Image.CopyTo(new FileStream(Directory.GetCurrentDirectory() + @"\wwwroot\" + config["ImageForlderName"] + @"\" + fileName, FileMode.Create));
                vm.Patient.ProfileName = fileName;
            }
            ViewData["IsEdit"] = true;
            patientService.Update(vm.Patient);
            vm.liCountry = countryService.GetAll();

            return View("NewPatient", vm);
        }
    }
}
