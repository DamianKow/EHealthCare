using EHealthCare.DataLayer;
using EHealthCare.Model.Models;
using EHealthCare.Model.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Mvc;


namespace EHealthCare.Web.Controllers
{
    public class PatientController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PatientController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        [Authorize(Roles = "Patient")]
        public ActionResult DataManage()
        {
            var userId = User.Identity.GetUserId();
            var patient = _context.Patients.Single(x => x.AccountId == userId);
            return View(patient);
        }

        [HttpPost]
        [Authorize(Roles = "Patient")]
        [ValidateAntiForgeryToken]
        public ActionResult ActualizeData(Patient model)
        {
            var userId = User.Identity.GetUserId();

            model.AccountId = userId;

            _context.Patients.AddOrUpdate(
                d => d.AccountId,
                model);
            _context.SaveChanges();

            return RedirectToAction("ShowTerms", "Patient");
            // return RedirectToAction("Index", "Manage");    
        }

        [HttpGet]
        [Authorize(Roles = "Patient")]
        public ActionResult ShowTerms()
        {

            var terms = _context.Terms
                .Include("Doctor")
                .Where(t => t.IsTaken == false);

            var viewModel = new PatientShowTermsViewModel()
            {
                Terms = terms
            };

            return View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Patient")]
        public ActionResult ShowTerms(string submitButton) // creates a visit on ShowTerm view.
        {

            if (ModelState.IsValid)
            {

                    int termId = Convert.ToInt32(submitButton);
                    var userId = User.Identity.GetUserId();
                    var currentTerm = _context.Terms
                        .Include("Doctor")
                        .Single(p => p.TermId == termId);
                    

                    var patient = _context.Patients
                        .Single(x => x.AccountId == userId);

                    if (currentTerm != null)
                    {
                        currentTerm.IsTaken = true;

                        var patientVisit = new PatientVisit
                        {
                            Date = currentTerm.DateTimeOfTerm,
                            Doctor = currentTerm.Doctor,
                            IsTookPlace = false,
                            Patient = patient,
                        };

                        _context.Visits.Add(patientVisit);
                        _context.SaveChanges();

                        TempData["Success"] = $"Successfully booked a visit on: {currentTerm.DateTimeOfTerm}";
                    }

            }

            return RedirectToAction("ShowVisits", "Patient");
        }

        [HttpGet]
        [Authorize(Roles = "Patient")]
        public ActionResult ShowVisits()
        {

            var userId = User.Identity.GetUserId();

            var visits = _context.Visits
                .Where(v => v.Patient.AccountId == userId)
                .ToList();

            var viewModel = new PatientShowVisitsViewModel
            {
                PatientVisits = visits
            };

            return View(viewModel);
        }

        [HttpGet]
        [Authorize(Roles = "Patient")]
        public ActionResult ShowPrescriptions()
        {
            var userId = User.Identity.GetUserId();

            var prescriptionMedicines = _context.PrecriptionMedicine
                .Include("Prescription")
                .Include("Medicines")
                .Where(p => p.Prescription.Patient.AccountId == userId);

            var viewModel = new PatientShowPrescriptionsViewModel
            {
                PrecriptionMedicines = prescriptionMedicines
            };

            return View(viewModel);
        }

        // Obsolete - might eventually use later.
        //[Authorize]
        //[HttpPost]
        //[Authorize(Roles = "Patient")]
        //public ActionResult Create(PatientViewModel viewModel)
        //{
        //    var patient = new Patient
        //    {
        //        AccountId = User.Identity.GetUserId(),
        //        Name = viewModel.Name,
        //        Surname = viewModel.Surname,
        //        Pesel = viewModel.Pesel,
        //        Sex = viewModel.Sex,
        //       // CreationTime = DateTime.Now,
        //        Street = viewModel.Street,
        //        City = viewModel.City,
        //        PostCode = viewModel.PostCode,
        //        Phone = viewModel.Phone,
        //        Age = viewModel.Age

        //    };

        //    _context.Patients.AddOrUpdate(
        //        p => p.Pesel,
        //        patient);
        //    _context.SaveChanges();

        //    return RedirectToAction("Index", "Home");

        //}
        //[Authorize]
        //[HttpGet]
        //public ActionResult Create()
        //{
        //    string accountId = User.Identity.GetUserId();
        //    var patient = (from c in _context.Patients where c.AccountId == accountId select c).FirstOrDefault();

        //    if (patient == null)
        //    {
        //        return View();
        //    }

        //    var viewModel = new PatientViewModel
        //    {
        //        Name = patient.Name.IsNullOrWhiteSpace() ? "Enter your Name" : patient.Name,
        //        Surname = patient.Surname.IsNullOrWhiteSpace() ? "Enter your Surname" : patient.Surname,
        //        Pesel = patient.Pesel,
        //        Sex = patient.Sex.IsNullOrWhiteSpace() ? "Man/Woman?" : patient.Sex,
        //        Street = patient.Street.IsNullOrWhiteSpace() ? "Enter your Street" : patient.Street,
        //        City = patient.City.IsNullOrWhiteSpace() ? "enter your City" : patient.City,
        //        PostCode = patient.PostCode.IsNullOrWhiteSpace() ? "Enter your Post code" : patient.PostCode,
        //        Phone = patient.Phone,
        //        Age = patient.Age
        //    };

        //    return View(viewModel);
        //}

    }
}