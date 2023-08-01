using System;
using System.Collections.Generic;
using AppointmentMDWebApp.Models;

namespace AppointmentMDWebApp
{
    public interface IPatientRepository
    {
        public IEnumerable<Patient> GetPatients();
    }
}
