using AmmanClinic.Models;

namespace AmmanClinic.Services
{
    public interface IPatientService
    {
        void Insert(PatientDTO patientDTO);

        List<PatientDTO> GetByName(string Name);

        PatientDTO Load(int Id);

        void Update(PatientDTO patientDTO);

        List<PatientDTO> GetAll();
    }
}
