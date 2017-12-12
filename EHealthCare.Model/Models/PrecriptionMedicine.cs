using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHealthCare.Model.Models
{
    public class PrecriptionMedicine
    {
        [Key]
        public int Id { get; set; }
        public virtual Medicines Medicines { get; set; }
        public virtual Prescription Prescription { get; set; }
    }
}
