using System.ComponentModel.DataAnnotations;

namespace AppointmentMDWebApp.Models
{
    public class Appointment
    {
        public Appointment() { }

        public int ApptID { get; set; }

        /*[Display(Name = "Time Edit")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: HH:mm:ss}")]*/
        public DateTime appointment { get; set; }

        public int PatientID { get; set; }
        public int PhysicianID { get; set; }
    }
}
