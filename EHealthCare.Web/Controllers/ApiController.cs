using System.Web.Mvc;

namespace EHealthCare.Web.Controllers
{
    public class ApiController : Controller
    {
        // GET: Api
        public ActionResult Doctors()
        {
            return View();
        }
    }
}