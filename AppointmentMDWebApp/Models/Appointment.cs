using System.ComponentModel.DataAnnotations;

namespace AppointmentMDWebApp.Models
{
    public class Appointment
    {
        public Appointment() { }

        public int ApptID { get; set; }
        public DateTime AppointmentStart { get; set; }
        public DateTime AppointmentEnd { get; set; }

        public int PatientID { get; set; }
        public int PhysicianID { get; set; }

        public IEnumerable<Physician> Physicians { get; set; }
    }
}
