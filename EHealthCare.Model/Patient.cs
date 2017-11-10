using System;
using System.ComponentModel.DataAnnotations;

namespace EHealthCare.Model
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Pesel { get; set; }
        public int Age { get; set; }
        public int Phone { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostCode { get; set; }
        public string Sex { get; set; }
        public DateTime CreationTime { get; set; }

    }
}
