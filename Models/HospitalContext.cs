using Microsoft.EntityFrameworkCore;
using Project.Models;
namespace Project.Models
{
    public class HospitalContext :DbContext
    {
        public HospitalContext(DbContextOptions<HospitalContext>  option) :base(option)
        {

        }
        public DbSet<Doctormaster> Doctormasters { get; set; }
        public DbSet<Employeemaster> Employees { get; set; }
        public DbSet<Medicaltreatmentcs> Medicaltreatmentcs { get; set; }
        public DbSet<Medicinemaster> Medicinemasters { get; set; }
        public DbSet<Servicemaster> Servicemasters { get; set; }
        public DbSet<Departmentmaster> Departmentmasters { get; set; }
        public DbSet<Roommaster> Roommasters { get; set; }
        public DbSet<Billing> Billings { get; set; }
        public DbSet<DischargePatient> DischargePatients { get; set; }
        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<Project.Models.ChangePassword>? ChangePassword { get; set; }
        public DbSet<Project.Models.AspnetUser>? AspnetUser { get; set; }

    }
}
