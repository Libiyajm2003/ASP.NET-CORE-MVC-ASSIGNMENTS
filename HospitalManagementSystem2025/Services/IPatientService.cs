using HospitalManagementSystem2025.Models;

namespace HospitalManagementSystem2025.Services
{
    public interface IPatientService
    {
        IEnumerable<Patient> GetAllPatients();
        List<Membership> GetAllMemberships();
        void AddPatient(Patient patient);
        void EditAndUpdatePatient(Patient patient);

        // Correct signature
        Patient GetPatientById(int id);
    }

}