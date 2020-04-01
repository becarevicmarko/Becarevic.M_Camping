using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Becarevic.M_Camping.Controllers
{
    public class CampingPlatzController : Controller
    {
        // GET: CampingPlatz
        public ActionResult Infos()
        {
            return View();
        }

        public ActionResult Preise()
        {
            return View();
        }

        public ActionResult Bilder()
        {
            return View();
        }
    }
}