using EHealthCare.Model.Models;
using System.Collections.Generic;

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
        public int Day { get; set; }
        public int Hour { get; set; }
    }

    public class ShowTermsViewModel
    {
        public IEnumerable<Term>  Terms { get; set; }
    }
}
