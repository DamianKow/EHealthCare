using EHealthCare.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Display(Name = "Date of term (YYYY-MM-DD HH:MM:SS)")]
        public DateTime DateTimeOfTerm { get; set; }
    }

    public class ShowTermsViewModel
    {
        public IEnumerable<Term>  Terms { get; set; }
    }

    public class DoctorShowVisitsViewModel
    {
        public IEnumerable<PatientVisit> Visits { get; set; }
    }

    public class ManagePrescriptionsViewModel
    {
        public int MedicineId { get; set; }
        public int PrescriptionId { get; set; }
        public int VisitId { get; set; }
        public string Comment { get; set; }
    }

    public class AddMedicineToPrescriptionViewModel
    {
        public int PrescriptionId { get; set; }
        public int MedicineId { get; set; }
    }
    
}
