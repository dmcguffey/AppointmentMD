using System;
using System.Collections.Generic;
using AppointmentMDWebApp.Models;

namespace AppointmentMDWebApp
{
    public interface IPhysicianRepository
    {
        public IEnumerable<Physician> GetPhysicians();

        public Physician GetPhysician(int id);

        public void UpdatePhysician (Physician physician);
    }
}
