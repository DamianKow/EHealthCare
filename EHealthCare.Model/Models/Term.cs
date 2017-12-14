using System;
using System.ComponentModel.DataAnnotations;

namespace EHealthCare.Model.Models
{
    public class Term
    {
        [Key]
        public int TermId { get; set; }
        public DateTime DateTimeOfTerm { get; set; }
        [Required]
        public Doctor Doctor { get; set; }
        public int DoctorId { get; set; }
        public bool IsTaken { get; set; }
    }
}
