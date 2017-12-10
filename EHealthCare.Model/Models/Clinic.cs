using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EHealthCare.Model.Models
{
    public class Clinic
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostCode { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }

    }
}