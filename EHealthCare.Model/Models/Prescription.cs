using System;
using System.ComponentModel.DataAnnotations;

namespace EHealthCare.Model.Models
{
    public class Prescription
    {
        [Key]
        public int Id { get; set; }
        public DateTime ExpirationDate { get; set; }
      
    }
}