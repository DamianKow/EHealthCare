﻿using EHealthCare.Model.Models;
using System.Collections.Generic;
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

    public class PatientShowTermsViewModel
    {
        public IEnumerable<Term> Terms { get; set; }
    }

    public class PatientShowVisitsViewModel
    {
        public IEnumerable<PatientVisit> PatientVisits { get; set; }
    }

    public class PatientShowPrescriptionsViewModel
    {
        public IEnumerable<Prescription> Prescriptions { get; set; }
        public IEnumerable<PrecriptionMedicine> PrecriptionMedicines { get; set; }
    }
    
}
