using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppointmentMDWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentMDWebApp.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentRepository repo;

        public AppointmentController(IAppointmentRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            var appointments = repo.GetAppointments();
            return View(appointments);
        }

        public IActionResult ViewAppointment(int id)
        {
            var appointment = repo.GetAppointment(id);
            return View(appointment);
        }

        public IActionResult UpdateAppointment(int id)
        {
            Appointment appt = repo.GetAppointment(id);
            if (appt == null)
            {
                return View("ProductNotFound");
            }
            return View(appt);
        }

        public IActionResult UpdateAppointmentToDatabase(Appointment Updatedappointment)
        {
            repo.UpdateAppointment(Updatedappointment);
            return RedirectToAction("ViewAppointment", new { id = Updatedappointment.ApptID });
        }

        public IActionResult MakeAppointment()
        {
            var appt = repo.AssignPhysician();
            return View(appt);
        }

        public IActionResult InsertAppointmentToDatabase(Appointment newAppointment)
        {
            repo.MakeAppointment(newAppointment);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteAppointment(Appointment appointment)
        {
            repo.DeleteAppointment(appointment);
            return RedirectToAction("Index");
        }

        public IActionResult ViewPhysicianAppointments(int PhysicianID)
        {
            var PhysicianAppointments = repo.GetPhysicianAppointments(PhysicianID);
            return View(PhysicianAppointments);
        }
    }
}