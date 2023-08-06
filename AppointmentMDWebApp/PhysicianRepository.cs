using AppointmentMDWebApp.Models;
using Dapper;
using System;
using System.Data;

namespace AppointmentMDWebApp
{
    public class PhysicianRepository : IPhysicianRepository
    {
        private readonly IDbConnection _conn;

        public PhysicianRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public Physician GetPhysician(int id)
        {
            return _conn.QuerySingle<Physician>("SELECT * FROM PHYSICIANS WHERE PHYSICIANID = @id", new { id = id });
        }

        public IEnumerable<Physician> GetPhysicians()
        {
            return _conn.Query<Physician>("SELECT * FROM PHYSICIANS;");
        }

        public void UpdatePhysician(Physician physician)
        {
            throw new NotImplementedException();
        }
    }
}
