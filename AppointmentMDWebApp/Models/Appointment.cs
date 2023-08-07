using System.ComponentModel.DataAnnotations;

namespace AppointmentMDWebApp.Models
{
    public class Appointment
    {
        public Appointment() { }

        public int ApptID { get; set; }
        //[Display(Name = "Appointment")]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/d/yyyy HH:mm}")]
        public DateTime? AppointmentStart { get; set; }
        public DateTime? AppointmentEnd { get; set; }

        public int PatientID { get; set; }
        public int PhysicianID { get; set; }

        public IEnumerable<Physician> Physicians { get; set; }
    }
}
