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

        public IEnumerable<Physician> GetPhysicians()
        {
            return _conn.Query<Physician>("SELECT * FROM PHYSICIANS;");
        }
    }
}
