using HospitalManagementSystem2025.Models;
using HospitalManagementSystem2025.Repositories;

namespace HospitalManagementSystem2025.Services
{
    public class PatientServiceImpl : IPatientService
    {
        private readonly IPatientRepository _patientRepository;

        public PatientServiceImpl(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            return _patientRepository.GetAllPatients();
        }

        public List<Membership> GetAllMemberships()
        {
            return _patientRepository.GetAllMemberships();
        }

        public void AddPatient(Patient patient)
        {
            _patientRepository.InsertPatient(patient);
        }

        public void EditAndUpdatePatient(Patient patient)
        {
            _patientRepository.UpdatePatient(patient);
        }

        public Patient GetPatientById(int id)
        {
            // This requires a corresponding repository method
            return _patientRepository.GetPatientById(id);
        }
    }
}
