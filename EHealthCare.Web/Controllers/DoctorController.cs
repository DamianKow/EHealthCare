using EHealthCare.DataLayer;
using EHealthCare.Model.Models;
using EHealthCare.Model.ViewModels;
using Microsoft.AspNet.Identity;
using System.Data.Entity.Migrations;
using System.Diagnostics;
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

        // GET: Doctor
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DataManage()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ActualizeData(Doctor model)
        {
            // TODO: Use new convention for dbcontext to avoid reusing a lot of code.
            ApplicationDbContext db = new ApplicationDbContext();

            Debug.Print(model.ToString());

            var userId = User.Identity.GetUserId();

            model.AccountId = userId;

            db.Doctors.AddOrUpdate(
                d => d.AccountId,
                model);
            db.SaveChanges();

            return RedirectToAction("Dashboard", "Home");
           // return RedirectToAction("Index", "Manage");    
        }


        public ActionResult MyVisit()
        {
            if (Request.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Dashboard", "Home");
            }
        }

        [HttpGet]
        public ActionResult AddTerm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTerm(AddTermViewModel viewModel)
        {
            var userId = User.Identity.GetUserId();
            var currentDoctor = _context.Doctors
                .Where(x => x.AccountId == userId)
                .FirstOrDefault();

            var term = new Term
            {
                Day = viewModel.Day,
                Hour = viewModel.Hour,
                Doctor = currentDoctor
            };

            _context.Terms.Add(term);
            _context.SaveChanges();

            return RedirectToAction("ShowTerm", "Doctor");
        }

        [HttpGet]
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
    }
}