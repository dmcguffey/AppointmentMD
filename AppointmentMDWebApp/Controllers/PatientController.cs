using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentMDWebApp.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientRepository repo;

        public PatientController(IPatientRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            var patients = repo.GetPatients();
            return View(patients);
        }

        public IActionResult ViewPatient(int id)
        {
            var patient = repo.GetPatient(id);
            return View(patient);
        }
    }
}
