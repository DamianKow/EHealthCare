using System.ComponentModel.DataAnnotations;

namespace EHealthCare.Model.Models
{
    public class Term
    {
        [Key]
        public int TermId { get; set; }
        public int Day { get; set; }
        public int Hour { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}
