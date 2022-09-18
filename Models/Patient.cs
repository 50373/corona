namespace Project.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public string PatientType { get; set; }
        public DateTime? Admitted{ get; set; }
        public DateTime? Discharge { get; set; } 
    }
}
