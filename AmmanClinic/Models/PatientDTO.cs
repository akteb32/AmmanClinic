using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using AmmanClinic.data;
using AutoMapper;


namespace AmmanClinic.Models
{

    [AutoMap(typeof(Patient), ReverseMap = true)]

    public class PatientDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please fillout the first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please fillout the last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please select gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please select phone")]
        public string Phone { get; set; }

        public string? Email { get; set; }

        [Required(ErrorMessage = "Please select country")]
        public int Country_Id { get; set; }

        public IFormFile Image { get; set; }

        public string? ProfileName { get; set; }


        public CountryDTO country { get; set; }
    }
}
