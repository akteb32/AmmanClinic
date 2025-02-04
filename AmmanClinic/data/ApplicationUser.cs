using Microsoft.AspNetCore.Identity;

namespace AmmanClinic.data
{
    public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }

        public DateTime DOB { get; set; }
    }
}
