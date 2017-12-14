using EHealthCare.DataLayer;
using EHealthCare.Model.Models;
using EHealthCare.Model.ViewModels;
using Microsoft.AspNet.Identity;
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
            return View();
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

            return RedirectToAction("Dashboard", "Home");
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

        [HttpGet]
        [Authorize(Roles = "Patient")]
        public ActionResult CreateVisit()
        {
            return View();
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