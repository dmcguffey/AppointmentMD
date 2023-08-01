using AppointmentMDWebApp.Models;
using Dapper;
using System;
using System.Data;

namespace AppointmentMDWebApp
{
    public class PatientRepository : IPatientRepository
    {
        private readonly IDbConnection _conn;
        public PatientRepository(IDbConnection conn)
        {
            _conn = conn;
        }


        public IEnumerable<Patient> GetPatients()
        {
            return _conn.Query<Patient>("SELECT * FROM PATIENTS;");
        }
    }
}
