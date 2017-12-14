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
            return View();
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

            return RedirectToAction("Dashboard", "Home");
           // return RedirectToAction("Index", "Manage");    
        }

        [HttpGet]
        [Authorize(Roles = "Doctor")]
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
        [Authorize(Roles = "Doctor")]
        public ActionResult AddTerm()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Doctor")]
        public ActionResult AddTerm(AddTermViewModel viewModel)
        {
            var userId = User.Identity.GetUserId();
            var currentDoctor = _context.Doctors
                .Where(x => x.AccountId == userId)
                .FirstOrDefault();

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
        public ActionResult RemoveTerm(string submitButton)
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

        }

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
    }
}