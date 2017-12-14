using EHealthCare.Model;
using EHealthCare.Model.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace EHealthCare.DataLayer
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<PatientVisit> Visits { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Term> Terms { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Medicines> Medicines { get; set; }
        public DbSet<PrecriptionMedicine> PrecriptionMedicine { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

       // public System.Data.Entity.DbSet<EHealthCare.Model.Models.Term> Terms { get; set; }
    }
}