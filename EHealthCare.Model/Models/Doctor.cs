using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHealthCare.Model.Models
{
    public class Doctor
    {
        [Key]
        public int Id { get; set; }
        public ApplicationUser Account { get; set; }
        [Required]
        public string AccountId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Pesel { get; set; }
        public string Phone { get; set; }
        public virtual Clinic Clinic { get; set; }
        public string Specialization { get; set; }


    }
}
