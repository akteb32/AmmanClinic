using System.ComponentModel.DataAnnotations;
namespace AmmanClinic.Models
{
    public class SignInDTO
    {
        [Required(ErrorMessage = "Please fill username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please fill password")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
