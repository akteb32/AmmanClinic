using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AmmanClinic.data
{
    [Table("Patients")]

    public class Patient
    {

        public int Id { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; } //nvarchar(max)

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(6)]
        public string Gender { get; set; } // nvarchar(6)

        [StringLength(20)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string? Email { get; set; }

        [ForeignKey("country")]
        public int Country_Id { get; set; }
        public virtual Country country { get; set; }

        public string? ProfileName { get; set; }
    }
}
