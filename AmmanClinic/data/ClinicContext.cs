using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;

namespace AmmanClinic.data
{
    public class ClinicContext: IdentityDbContext<ApplicationUser>
    {
        IConfiguration config;
        public ClinicContext(IConfiguration _config)
        {
            config = _config;
        }

        public DbSet<Country> countries { get; set; }

        public DbSet<Patient> patients { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer(config.GetConnectionString("clinicConn"));
            base.OnConfiguring(optionsBuilder);
        }
    }
}
