using AmmanClinic.data;
using AmmanClinic.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace AmmanClinic.Services
{
    public class PatientService : IPatientService
    {
        ClinicContext context;
        IMapper mapper;
        public PatientService(ClinicContext _context, IMapper _mapper)
        {
            mapper = _mapper;
            context = _context;
        }
        public void Insert(PatientDTO patientDTO)
        {
            Patient newPatient = mapper.Map<Patient>(patientDTO);
            context.patients.Add(newPatient);
            context.SaveChanges();
        }

        public void Update(PatientDTO patientDTO)
        {
            Patient patient = mapper.Map<Patient>(patientDTO);
            context.patients.Attach(patient);
            context.Entry(patient).State = EntityState.Modified;
            context.SaveChanges();
        }

        public List<PatientDTO> GetByName(string Name)
        {
           
            List<Patient> allPatients = context.patients.Where(p => p.FirstName.Contains(Name) || p.LastName.Contains(Name)).ToList();
            List<PatientDTO> patients = mapper.Map<List<PatientDTO>>(allPatients);
            return patients;
        }


        public List<PatientDTO> GetAll()
        {
            List<Patient> allPatients = context.patients.ToList();
            List<PatientDTO> patients = mapper.Map<List<PatientDTO>>(allPatients);

            return patients;
        }

        public PatientDTO Load(int Id)
        {
            Patient patient = context.patients.Find(Id);

            PatientDTO patientDTO = mapper.Map<PatientDTO>(patient);

            return patientDTO;
        }
    }
}
