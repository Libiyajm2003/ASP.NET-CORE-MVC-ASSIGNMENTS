using Microsoft.AspNetCore.Mvc;
using ProfessorApp.Models;
using ProfessorApp.Services;

namespace ProfessorApp.Controllers
{
    public class ProfessorController : Controller
    {
        // Field
        private readonly IProfessorService _professorService;

        // DI Constructor
        public ProfessorController(IProfessorService professorService)
        {
            _professorService = professorService;
        }

        // GET: Professor/List
        [HttpGet]
        public IActionResult List()
        {
            var professors = _professorService.GetAllProfessor();
            return View(professors);
        }

        // GET: show form
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Departments = _professorService.GetAllDepartments();
            return View();
        }

        // POST: insert professor
        [HttpPost]
        public IActionResult Create(Professor professor)
        {
            if (ModelState.IsValid)
            {
                _professorService.AddProfessor(professor);
                return RedirectToAction("List");
            }
            ViewBag.Departments = _professorService.GetAllDepartments();
            return View(professor);
        }

        // GET: Professor/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Get professor by ID
            var professor = _professorService.GetProfessorById(id);
            if (professor == null)
            {
                return NotFound();
            }

            // Load departments for dropdown
            ViewBag.Departments = _professorService.GetAllDepartments();

            return View(professor);
        }

        // POST: Professor/Edit
        [HttpPost]
        public IActionResult Edit(Professor professor)
        {
            if (ModelState.IsValid)
            {
                _professorService.UpdateProfessor(professor);
                return RedirectToAction("List");
            }

            // Reload dropdown if validation fails
            ViewBag.Departments = _professorService.GetAllDepartments();
            return View(professor);
        }
    }
}
