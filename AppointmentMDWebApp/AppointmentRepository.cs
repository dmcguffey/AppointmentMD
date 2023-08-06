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
            _conn.Execute("INSERT INTO appointments (appointment, appointmentEnd, patientID, physicianID) VALUES(@appointment,@appointmentEnd,@patientID, @physicianID);",
                new {appointment = appointment.appointment, appointmentEnd = appointment.appointmentEnd, patientID = appointment.PatientID, physicianID = appointment.PhysicianID });
        }

        public Appointment GetAppointment(int id)
        {
            return _conn.QuerySingleOrDefault<Appointment>("SELECT * FROM appointments WHERE ApptID = @id", new { id = id });
        }

        public IEnumerable<Appointment> GetAppointments()
        {
            return _conn.Query<Appointment>("SELECT * FROM appointments;");
        }

        public void UpdateAppointment(Appointment appointment)
        {
            _conn.Execute("UPDATE appointments SET appointment = @appointment, appointmentEnd = @appointmentEnd, patientID = @PatientID, PhysicianID = @physicianID WHERE ApptID = @ApptID;",
                new { appointment = appointment.appointment, appointmentEnd = appointment.appointmentEnd, PatientID = appointment.PatientID, physicianID = appointment.PhysicianID, ApptID = appointment.ApptID });
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
