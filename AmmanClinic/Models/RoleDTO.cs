using System.ComponentModel.DataAnnotations;
namespace AmmanClinic.Models
{
    public class RoleDTO
    {
        [Required(ErrorMessage = "Please fill out the role name")]
        public string Name { get; set; }
    }
}
