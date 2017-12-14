using System.Web.Mvc;

namespace EHealthCare.Web.Controllers
{
    public class ErrorController : Controller
    {
       
        public ActionResult Failed()
        {
            Response.StatusCode = 404;
            Response.TrySkipIisCustomErrors = true;
            return View();
        }
    }
}