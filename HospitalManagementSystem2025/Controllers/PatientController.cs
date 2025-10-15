using HospitalManagementSystem2025.Models;
using HospitalManagementSystem2025.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace HospitalManagementSystem2025.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;

        // Constructor with Dependency Injection
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        // GET: Patient/List
        [HttpGet]
        public IActionResult List()
        {
       List<Patient> patients = _patientService.GetAllPatients().ToList();
            return View(patients);
        }

        // GET: Patient/Create
        [HttpGet]
        public IActionResult Create()
        {
            // For JS to auto-fill MemberDescription/InsuredAmount
            ViewBag.Memberships = _patientService.GetAllMemberships();

            return View();
        }

        // POST: Patient/Create
        [HttpPost]
        public IActionResult Create([Bind] Patient patient)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _patientService.AddPatient(patient);
                }
                return RedirectToAction("List");
            }
            catch 
            {
                return View();
            }
        }

        // GET: Patient/Edit/{id}
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Memberships = _patientService.GetAllMemberships();

            Patient patient = _patientService.GetPatientById(id);
       

            return View(patient);
        }

        [HttpPost]
        public IActionResult Edit([Bind] int id, Patient patient)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _patientService.EditAndUpdatePatient(patient);
                }
                return RedirectToAction("List");
            }
            catch 
            {
                return View();
            }
        }
    }
}
