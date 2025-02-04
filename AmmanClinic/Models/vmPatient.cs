namespace AmmanClinic.Models
{
    public class vmPatient
    {
        public PatientDTO Patient { get; set; }

        public List<CountryDTO> liCountry { get; set; }
    }
}
