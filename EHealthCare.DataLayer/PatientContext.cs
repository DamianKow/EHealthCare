using EHealthCare.Model;
using System.Data.Entity;

namespace EHealthCare.DataLayer
{
    public class PatientContext : ApplicationDbContext
    {
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }

}

