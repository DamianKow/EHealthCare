using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHealthCare.Model.Models
{
    public class Term
    {
        [Key]
        public int Id { get; set; }
        public int Day { get; set; }
        public int Hour { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}
