using AppointmentMDWebApp.Models;
using Dapper;
using System;
using System.Data;
using System.Windows.Markup;
using System.Collections.Generic;

namespace AppointmentMDWebApp
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly IDbConnection _conn;

        public AppointmentRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public void MakeAppointment(Appointment appointment)
        {
            _conn.Execute("INSERT INTO appointments (AppointmentStart, appointmentEnd, PatientID, PhysicianID) VALUES(@AppointmentStart,@AppointmentEnd,@PatientID, @PhysicianID);",
                new {AppointmentStart = appointment.AppointmentStart, appointmentEnd = appointment.AppointmentEnd, PatientID = appointment.PatientID, PhysicianID = appointment.PhysicianID });
        }

        public Appointment GetAppointment(int id)
        {
            return _conn.QuerySingleOrDefault<Appointment>("SELECT * FROM appointments WHERE ApptID = @id", new { id = id });
        }

        public IEnumerable<Appointment> GetAppointments()
        {
            return _conn.Query<Appointment>("SELECT * FROM appointments ORDER BY AppointmentStart;");
        }

        public void UpdateAppointment(Appointment appointment)
        {
            try
            {
                _conn.Execute("UPDATE appointments SET AppointmentStart = @AppointmentStart, AppointmentEnd = @AppointmentEnd, PatientID = @PatientID, PhysicianID = @PhysicianID WHERE ApptID = @ApptID;",
                new { AppointmentStart = appointment.AppointmentStart, AppointmentEnd = appointment.AppointmentEnd, PatientID = appointment.PatientID, PhysicianID = appointment.PhysicianID, ApptID = appointment.ApptID });
            }
            catch (Exception ex)
            {
                _conn.Query<Appointment>("SELECT * FROM appointments;");
            }
        }

        public IEnumerable<Physician> GetPhysicians()
        {
            return _conn.Query<Physician>("SELECT * FROM PHYSICIANS;");
        }

        public Appointment AssignPhysician()
        {
            var physicianList = GetPhysicians();
            var appointment = new Appointment();
            appointment.Physicians = physicianList;
            return appointment;
        }

        public void DeleteAppointment(Appointment appointment)
        {
            _conn.Execute("DELETE FROM appointments WHERE ApptID = @ApptID;", new { ApptID = appointment.ApptID });
        }
    }
}
