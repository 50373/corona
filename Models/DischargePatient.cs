namespace Project.Models
{
    public class DischargePatient
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public DateTime InPatient{ get; set; }
    public DateTime OutPatient {get; set;}


    }
}
