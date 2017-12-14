using System.Web.Mvc;

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

            if (User.IsInRole("Doctor"))
            {
                return RedirectToAction("DataManage", "Doctor");
            }
            else if(User.IsInRole("Patient"))
            { 
                return RedirectToAction("DataManage", "Patient");
            }

            return RedirectToAction("Register", "Account");

        }

        public ActionResult Dashboard()
        {
            return View();
        }
        
    }
}