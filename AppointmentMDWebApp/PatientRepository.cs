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
            return _conn.QuerySingle<Patient>("SELECT * FROM PATIENTS WHERE PATIENTID = @id", new { id = id });
        }

        public IEnumerable<Patient> GetPatients()
        {
            return _conn.Query<Patient>("SELECT * FROM PATIENTS;");
        }

        public void UpdatePatient(Patient patient)
        {
            _conn.Execute("UPDATE patients SET Name = @Name, DateOfBirth = @DateOfBirth, Gender = @Gender, Diagnosis = @Diagnosis, PhysicianID = @PhysicianID WHERE PatientID = @PatientID;",
                new { Name = patient.Name, DateOfBirth = patient.DateOfBirth, Gender = patient.Gender, Diagnosis = patient.Diagnosis, PhysicianID = patient.PhysicianID, PatientID = patient.PatientID });
        }
    }
}
