using AmmanClinic.data;
using AutoMapper;
using System.ComponentModel.DataAnnotations;


namespace AmmanClinic.Models
{

    [AutoMap(typeof(Country), ReverseMap = true)]

    public class CountryDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please fill out the country name")]
        public string Name { get; set; }
    }
}
