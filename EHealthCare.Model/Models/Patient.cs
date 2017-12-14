using System.ComponentModel.DataAnnotations;

namespace EHealthCare.Model.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }
        public ApplicationUser Account { get; set; }
        [Required]
        public string AccountId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Pesel { get; set; }
        public int Age { get; set; }
        public int Phone { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostCode { get; set; }
        public string Sex { get; set; }

    }
}
