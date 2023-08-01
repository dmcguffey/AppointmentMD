using System;
using System.Collections.Generic;
using AppointmentMDWebApp.Models;

namespace AppointmentMDWebApp
{
    public interface IAppointmentRepository
    {
        public IEnumerable<Appointment> GetAppointments();

        public Appointment GetAppointment(int id);
    }
}
