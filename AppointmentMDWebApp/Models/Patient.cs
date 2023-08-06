namespace AppointmentMDWebApp.Models
{
    public class Patient
    {
        public Patient() { }
        public int PatientID { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Diagnosis { get; set; }
        public int PhysicianID { get; set; }
    }
}
