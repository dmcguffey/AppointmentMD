using System;

namespace AppointmentMDWebApp.Models
{
    public class Physician
    {
        public Physician() { }

        public int PhysicianID { get; set; }
        public string Name { get; set; }
        public string Specialty { get; set; }
        public string Location { get; set; }
    }
}
