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

        public IActionResult UpdateAppointmentToDatabase(Appointment appointment)
        {
            repo.UpdateAppointment(appointment);
            return RedirectToAction("ViewAppointment", new { id = appointment.ApptID });
            /*if (ModelState.IsValid)
            {
                try
                {
                    repo.UpdateAppointment(appointment);
                    TempData["Message"] = "Appointment updated successfully.";

                    // Reload the updated appointment from the database to get the latest data
                    Appointment reloadedAppointment = repo.GetAppointment(appointment.ApptID);
                    return View("ViewAppointment", reloadedAppointment);
                }
                catch (Exception ex)
                {
                    TempData["Error"] = "An error occurred while updating the appointment.";
                }
            }
            else
            {
                TempData["Error"] = "Invalid data. Please check the input fields.";
            }

            // If there was an error or ModelState is not valid, return to the same view
            return View("ViewAppointment", appointment);*/
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
    }
}
