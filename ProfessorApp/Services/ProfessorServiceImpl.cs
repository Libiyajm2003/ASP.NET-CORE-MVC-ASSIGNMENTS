using ProfessorApp.Models;
using ProfessorApp.Repositories;

namespace ProfessorApp.Services
{
    public class ProfessorServiceImpl : IProfessorService
    {
        // field 
        private readonly IProfessorRepository _professorRepository;

        // DI constructor
        public ProfessorServiceImpl(IProfessorRepository professorRepository)
        {
            _professorRepository = professorRepository;
        }

        public IEnumerable<Professor> GetAllProfessor()
        {
            return _professorRepository.GetAllProfessor();
        }

        public List<Department> GetAllDepartments()
        {
            return _professorRepository.GetAllDepartments();
        }
        public void AddProfessor(Professor professor)
        {
            _professorRepository.AddProfessor(professor);
        }

        public Professor GetProfessorById(int professorId)
        {
            return _professorRepository.GetProfessorById(professorId);
        }

        public void UpdateProfessor(Professor professor)
        {
            _professorRepository.UpdateProfessor(professor);
        }
    }
}
