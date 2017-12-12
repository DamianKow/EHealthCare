using System.ComponentModel.DataAnnotations;

namespace EHealthCare.Model.ViewModels
{
    public class PatientViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Pesel { get; set; }
        public int Age { get; set; }
        public int Phone { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        [Display(Name = "Post code")]
        public string PostCode { get; set; }
        public string Sex { get; set; }

    }
}
