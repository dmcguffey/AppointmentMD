using System;
using System.Collections.Generic;
using AppointmentMDWebApp.Models;

namespace AppointmentMDWebApp
{
    public interface IAppointmentRepository
    {
        public IEnumerable<Appointment> GetAppointments();

        public Appointment GetAppointment(int id);

        public void UpdateAppointment(Appointment appointment);

        public void MakeAppointment(Appointment appointment);

        public IEnumerable<Physician> GetPhysicians();

        public Appointment AssignPhysician();

        public void DeleteAppointment(Appointment appointment);

    }
}
