using EHealthCare.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EHealthCare.Model.ViewModels
{
    public class DoctorViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Pesel { get; set; }
        public string Phone { get; set; }
        public virtual Clinic Clinic { get; set; }
        public string Specialization { get; set; }
    }

    public class AddTermViewModel
    {
        [Display(Name = "Date of term (YYYY-MM-DD HH:MM:SS)")]
        public DateTime DateTimeOfTerm { get; set; }
    }

    public class ShowTermsViewModel
    {
        public IEnumerable<Term>  Terms { get; set; }
    }
}
