using EHealthCare.Model;
using System.Data.Entity;

namespace EHealthCare.DataLayer
{
    public class PatientContext : ApplicationDbContext
    {
        public DbSet<Patient> Patients { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }

}

