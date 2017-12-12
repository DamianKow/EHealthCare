using System.ComponentModel.DataAnnotations;

namespace EHealthCare.Model.Models
{
    public class Medicines
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ActiveSubstance { get; set; }
    }
}