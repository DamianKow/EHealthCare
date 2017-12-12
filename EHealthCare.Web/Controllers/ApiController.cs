using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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