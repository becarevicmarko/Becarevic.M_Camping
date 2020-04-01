using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Becarevic.M_Camping.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ÜberUns()
        {
            return View();
        }

        public ActionResult Impressum()
        {
            return View();
        }
    }
}