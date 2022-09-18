namespace Project.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int Patientid { get; set; }  
        public string Patientname { get; set; }   
        public string Departmentid { get; set; }
        public int Doctorid { get; set; }   
        public  string Doctorname{ get; set; }
    }
}
