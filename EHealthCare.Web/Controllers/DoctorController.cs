using EHealthCare.DataLayer;
using EHealthCare.Model.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Web.Mvc;

namespace EHealthCare.Web.Controllers
{
    public class DoctorController : Controller
    {
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

            ApplicationDbContext db = new ApplicationDbContext();

            Debug.Print(model.ToString());

            var userId = User.Identity.GetUserId();

            model.AccountId = userId;

            db.Doctors.AddOrUpdate(
                d => d.AccountId,
                model);
            db.SaveChanges();


            //db.Doctors.AddOrUpdate(model);
            //db.SaveChanges();

            //var userId = User.Identity.GetUserId();
            //model.AccountId = userId;
            //if (ModelState.IsValid)
            //{

            //    db.SaveChanges();
            //    return RedirectToAction("Dashboard", "Home");
            //}
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
        public ActionResult AddTerm(Term term)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Terms.Add(term);
                db.SaveChanges();
            }

            return RedirectToAction("ShowTerm", "Doctor");
        }

        public ActionResult ShowTerm()
        {
            return View();
        }
    }
}