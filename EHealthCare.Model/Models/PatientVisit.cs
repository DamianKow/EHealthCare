using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHealthCare.Model.Models
{
    public class PatientVisit
    {
        [Key]
        public int Id { get; set; }

        public virtual Doctor Doctor { get; set; }
        public DateTime Date { get; set; }
        public bool IsTookPlace { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public int Pesel { get; set; }
        public int Age { get; set; }
        public int Phone { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostCode { get; set; }
        public string Sex { get; set; }
    }
}
