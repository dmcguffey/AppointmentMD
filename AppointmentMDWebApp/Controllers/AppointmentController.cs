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
    }
}
