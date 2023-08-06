using AppointmentMDWebApp.Models;
using Dapper;
using System;
using System.Data;
using System.Globalization;

namespace AppointmentMDWebApp
{
    public class PatientRepository : IPatientRepository
    {
        private readonly IDbConnection _conn;
        public PatientRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public Patient GetPatient(int id)
        {
            return _conn.QuerySingle<Patient>("SELECT * FROM PATIENTS WHERE PATIENTID = @id", new {id = id});
        }

        public IEnumerable<Patient> GetPatients()
        {
            return _conn.Query<Patient>("SELECT * FROM PATIENTS;");
        }

    }
}
