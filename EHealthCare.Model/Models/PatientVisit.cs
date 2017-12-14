using System;
using System.ComponentModel.DataAnnotations;

namespace EHealthCare.Model.Models
{
    public class PatientVisit
    {
        [Key]
        public int Id { get; set; }

        public virtual Doctor Doctor { get; set; }
        public DateTime Date { get; set; }
        public bool? IsTookPlace { get; set; }
        public Prescription Prescription { get; set; }
        public int? PrescriptionId { get; set; }
        public virtual Patient Patient { get; set; }
        public string MedicalExamination { get; set; }
    }
}
