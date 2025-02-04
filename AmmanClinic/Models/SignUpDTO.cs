using System.ComponentModel.DataAnnotations;
namespace AmmanClinic.Models
{
    public class SignUpDTO
    {
        [Required(ErrorMessage = "Please fill Name of user")]
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        [Required(ErrorMessage = "Please fill email of user")]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
