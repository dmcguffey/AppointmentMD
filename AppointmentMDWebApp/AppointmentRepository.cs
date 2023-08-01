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

        public Appointment GetAppointment(int id)
        {
            return _conn.QuerySingleOrDefault<Appointment>("SELECT * FROM appointments WHERE ApptID = @id", new {id = id}); //not producing any results?
        }

        public IEnumerable<Appointment> GetAppointments()
        {
            return _conn.Query<Appointment>("SELECT * FROM appointments;");
        }
    }
}
