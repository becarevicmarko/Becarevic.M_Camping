using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Becarevic.M_Camping.Models;

namespace Becarevic.M_Camping.Controllers
{
    public class ReservierungController : Controller
    {
        // GET: Reservierung
        [HttpGet]
        public ActionResult Anfragen()
        {
            return View(new Reservierung());
        }
        
        [HttpPost]
        public ActionResult Anfragen(Reservierung reservierung)
        {


            if (reservierung == null)
            {
                return RedirectToAction("Registration");
            }
            CheckUserData(reservierung);

            if (!ModelState.IsValid)
            {
                return View(reservierung);
            }

            else
            {

                return View("Message", new Message("Reservierung", "Ihre Daten wurden erfolgreich abgespeichert"));
            }

        }
            
        private void CheckUserData(Reservierung reservierung)
        {
            if (reservierung == null)
            {
                return;
            }
            if (string.IsNullOrEmpty(reservierung.Firstname.Trim()))
            {
                ModelState.AddModelError("Firstname", "Vorname ist ein Pflichtfeld");
            }

            if (string.IsNullOrEmpty(reservierung.Lastname.Trim()))
            {
                ModelState.AddModelError("Lastname", "Nachname ist ein Pflichtfeld");
            }

            if (string.IsNullOrEmpty(reservierung.Street.Trim()))
            {
                ModelState.AddModelError("Street", "Straße ist ein Pflichtfeld");
            }

            if (reservierung.Category == Category.notSpecified)
            {
                ModelState.AddModelError("Category", "Bitte wählen Sie die Kategorie aus");
            }

        }

    }
}
