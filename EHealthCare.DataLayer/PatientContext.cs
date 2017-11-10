using EHealthCare.Model;
using System.Data.Entity;

namespace EHealthCare.DataLayer
{
    public class PatientContext : DbContext
    {

        public PatientContext() : base("DefaultConnection")
        {
            
        }

        public DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }

}

