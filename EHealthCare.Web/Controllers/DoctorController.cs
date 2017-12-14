using EHealthCare.DataLayer;
using EHealthCare.Model.Models;
using EHealthCare.Model.ViewModels;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web.Mvc;

namespace EHealthCare.Web.Controllers
{
    public class DoctorController : Controller
    {

        private readonly ApplicationDbContext _context;


        public DoctorController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        [Authorize(Roles = "Doctor")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Doctor")]
        public ActionResult DataManage()
        {
            var userId = User.Identity.GetUserId();
            var doctor = _context.Doctors.SingleOrDefault(x => x.AccountId == userId);
            return View(doctor);
        }

        [HttpPost]
        [Authorize(Roles = "Doctor")]
        [ValidateAntiForgeryToken]
        public ActionResult ActualizeData(Doctor model)
        {
            var userId = User.Identity.GetUserId();

            model.AccountId = userId;

            _context.Doctors.AddOrUpdate(
                d => d.AccountId,
                model);
            _context.SaveChanges();

            return RedirectToAction("ShowTerm", "Doctor");
           // return RedirectToAction("Index", "Manage");    
        }

        [HttpGet]
        [Authorize(Roles = "Doctor")]
        public ActionResult AddTerm()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Doctor")]
        public ActionResult ManagePrescriptions()
        {
            var userId = User.Identity.GetUserId();

            var visits = _context.Visits
                .Include("Patient")
                .Where(v => v.Doctor.AccountId == userId)
                .AsEnumerable()
                .Select(s => new
                {
                    Value = s.Id,
                    Text = $"Visit of: {s.Patient.Name} {s.Patient.Surname} on {s.Date}"
                })
                .ToList();

            var medicines = _context.Medicines
                .AsEnumerable()
                .Select(s => new
                {
                    Value = s.Id,
                    Text = $"{s.Name} with {s.ActiveSubstance} inside"
                })
                .ToList();

            var prescriptions = _context.Prescriptions
                .Include("Patient")
                .Where(p => p.Doctor.AccountId == userId)
                .AsEnumerable()
                .Select(s => new
                {
                    Value = s.Id,
                    Text = $"Prescription #{s.Id} for {s.Patient.Name} {s.Patient.Surname}"
                })
                .ToList();
                
            var prescriptionMedicines = _context.PrecriptionMedicine
                .Where(p => p.Prescription.Doctor.AccountId == userId);

            ViewBag.Prescriptions = new SelectList(prescriptions, "Value", "Text");
            ViewBag.Medicines = new SelectList(medicines, "Value", "Text");
            ViewBag.Visits = new SelectList(visits, "Value", "Text");

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Doctor")]
        public ActionResult ManagePrescriptions(ManagePrescriptionsViewModel viewModel, string submitButton)
        {
            var userId = User.Identity.GetUserId();
            var currentDoctor = _context.Doctors
                .SingleOrDefault(x => x.AccountId == userId);

            
            
            if (submitButton == "prescription")
            {
                var visit = _context.Visits.Include("Patient").SingleOrDefault(x => x.Id == viewModel.VisitId);

                visit.IsTookPlace = true;

                if (!viewModel.Comment.IsNullOrWhiteSpace())
                {
                    visit.MedicalExamination = viewModel.Comment;
                }

                var prescription = new Prescription
                {
                    Doctor = currentDoctor,
                    ExpirationDate = DateTime.Now.AddDays(30),
                    Patient = visit.Patient
                };

                _context.Prescriptions.Add(prescription);
                _context.SaveChanges();

                return RedirectToAction("ManagePrescriptions", "Doctor");
            }
            else
            {
                var medicine = _context.Medicines.Find(viewModel.MedicineId);
                var prescription = _context.Prescriptions.Find(viewModel.PrescriptionId);
                var prescriptionMedicine = new PrecriptionMedicine
                {
                    Medicines = medicine,
                    Prescription = prescription
                };

                _context.PrecriptionMedicine.Add(prescriptionMedicine);
                _context.SaveChanges();

                return RedirectToAction("ShowPrescriptions", "Doctor");
            }

            
            
            
        }

        [HttpPost]
        [Authorize(Roles = "Doctor")]
        public ActionResult AddTerm(AddTermViewModel viewModel)
        {
            var userId = User.Identity.GetUserId();
            var currentDoctor = _context.Doctors
                .SingleOrDefault(x => x.AccountId == userId);

            var term = new Term
            {
                DateTimeOfTerm = viewModel.DateTimeOfTerm,
                Doctor = currentDoctor
            };

            _context.Terms.Add(term);
            _context.SaveChanges();

            return RedirectToAction("ShowTerm", "Doctor");
        }

        [HttpPost]
        [Authorize(Roles = "Doctor")]
        public ActionResult ShowTerm(string submitButton)
        {
            if (ModelState.IsValid)
            {
                var currentTerm = _context.Terms
                    .Find(Convert.ToInt32(submitButton));

                if (currentTerm != null)
                {
                    _context.Terms.Remove(currentTerm);
                    _context.SaveChanges();
                }

            }

            return RedirectToAction("ShowTerm", "Doctor");

        } // it is removing term on ShowTerm view.

        [HttpGet]
        [Authorize(Roles = "Doctor")]
        public ActionResult ShowTerm()
        {

            var userId = User.Identity.GetUserId();

            var terms = _context.Terms
                .Where(x => x.Doctor.AccountId == userId);

            var viewModel = new ShowTermsViewModel
            {
                Terms = terms
            };

            return View(viewModel);
        }

        public ActionResult ShowVisits()
        {
            var userId = User.Identity.GetUserId();

            var visits = _context.Visits
                .Where(v => v.Doctor.AccountId == userId)
                .ToList();

            var viewModel = new DoctorShowVisitsViewModel
            {
                Visits = visits
            };

            return View(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Doctor")]
        public ActionResult CompleteVisit(string submitButton)
        {
            if (ModelState.IsValid)
            {
                var currentVisit = _context.Visits
                    .Find(Convert.ToInt32(submitButton));

                if (currentVisit != null)
                {
                    currentVisit.IsTookPlace = true;
                    TempData["Success"] = $"Successfully marked a visit on: {currentVisit.Date}";
                    _context.SaveChanges();
                }

            }

            return RedirectToAction("ShowVisits", "Doctor");

        }

        [HttpGet]
        [Authorize(Roles = "Doctor")]
        public ActionResult ShowPrescriptions()
        {
            var userId = User.Identity.GetUserId();

            var prescriptions = _context.Prescriptions
                .Where(p => p.Doctor.AccountId == userId)
                .ToList();

            var prescriptionMedicines = _context.PrecriptionMedicine
                .Include("Prescription")
                .Include("Medicines")
                .Where(p => p.Prescription.Doctor.AccountId == userId)
                .ToList();

            var viewModel = new ManagePrescriptionsViewModel
            {
                Prescriptions = prescriptions,
                PrecriptionMedicines = prescriptionMedicines
            };

            return View(viewModel);
        }
    }
}