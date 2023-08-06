using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentMDWebApp.Controllers
{
    public class PhysicianController : Controller
    {
        private readonly IPhysicianRepository repo;

        public PhysicianController(IPhysicianRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            var physicians = repo.GetPhysicians();
            return View(physicians);
        }

        public IActionResult ViewPhysician(int id)
        {
            var physician = repo.GetPhysician(id);
            return View(physician);
        }
    }
}
