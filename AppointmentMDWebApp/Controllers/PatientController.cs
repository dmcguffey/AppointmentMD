using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointmentMDWebApp.Models;
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

        public IActionResult UpdatePatient(int id)
        {
            Patient pt = repo.GetPatient(id);
            if (pt == null)
            {
                return View("Patient Not Found.");
            }
            return View(pt);
        }

        public IActionResult UpdatePatientToDatabase(Patient UpdatedPatient)
        {
            repo.UpdatePatient(UpdatedPatient);
            return RedirectToAction("ViewPatient", new { id = UpdatedPatient.PatientID });
        }
    }
}
