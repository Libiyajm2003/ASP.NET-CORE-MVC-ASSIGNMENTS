using ProfessorApp.Models;

namespace ProfessorApp.Services
{
    public interface IProfessorService
    {
        IEnumerable<Professor> GetAllProfessor();
        List<Department> GetAllDepartments();
        void AddProfessor(Professor professor);
        Professor GetProfessorById(int professorId);
        void UpdateProfessor(Professor professor);
    }
}

