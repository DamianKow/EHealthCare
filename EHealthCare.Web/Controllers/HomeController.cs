using EHealthCare.DataLayer;
using EHealthCare.Model;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EHealthCare.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("VerifyUserData", "Home");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public ActionResult VerifyUserData()
        {

            ApplicationDbContext db = new ApplicationDbContext();
            //var currentUser = Membership.GetUser(User.Identity.Name);
            var userId = User.Identity.GetUserId();
            //Guid id = (Guid)currentUser.ProviderUserKey;

            Debug.Print(userId.ToString());

            //var user = from u in db.Users
            //           where u.Id.Equals(userId.ToString())
            //           select u;

            var doctors = from d in db.Doctors
                          where d.AccountId.Equals(userId.ToString())
                          select d;

            var doctorsList = doctors.ToList();

            Debug.Print("List size = " + doctorsList.Count);
            if(doctorsList == null || doctorsList.Count == 0)
            {
                Debug.Print("Brak doktora w bazie");
                return RedirectToAction("DataManage", "Doctor");
            }

            Debug.Print("Doktor " + doctors.ToString());

            return RedirectToAction("Dashboard", "Home");
        }

        public ActionResult Dashboard()
        {
            return View();
        }
        
    }
}