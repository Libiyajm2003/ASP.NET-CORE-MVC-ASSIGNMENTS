using HospitalManagementSystem2025.Models;
using System.Collections.Generic;

namespace HospitalManagementSystem2025.Repositories
{
    public interface IPatientRepository
    {
        // List all patients
        IEnumerable<Patient> GetAllPatients();

        // List all memberships
        List<Membership> GetAllMemberships();

        // Insert a new patient
        void InsertPatient(Patient patient);

        // Update an existing patient
        void UpdatePatient(Patient patient);

        // Get a single patient by ID
        Patient GetPatientById(int id);
    }
}
