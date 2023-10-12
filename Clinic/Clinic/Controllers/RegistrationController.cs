using Clinic.Models;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace Clinic.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        public ActionResult Registration(RegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.SelectedUserType == "Doctor")
                {
                    // Process Doctor registration
                    ClinicEntities db = new ClinicEntities();
                    db.Doctors.Add(model.Doctor);
                    db.SaveChanges();
                }
                else if (model.SelectedUserType == "Patient")
                {
                    // Process Patient registration
                    ClinicEntities db = new ClinicEntities();
                    db.Patients.Add(model.Patient);
                    db.SaveChanges();
                }
            }

            return View("Index");
        }
    }
}