using Clinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Clinic.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(RegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                using (ClinicEntities db = new ClinicEntities())
                {
                    // First, check if the entered username and password match a doctor's account
                    var doctor = db.Doctors.FirstOrDefault(a => a.Username.Equals(model.Username) && a.Password.Equals(model.Password));

                    // If no doctor is found, check if the entered username and password match a patient's account
                    var patient = db.Patients.FirstOrDefault(a => a.Username.Equals(model.Username) && a.Password.Equals(model.Password));

                    if (doctor != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Username, false); // Authenticate the user
                        // Doctor login logic
                        Session["DoctorID"] = doctor.DoctorID.ToString();
                        Session["Username"] = doctor.Username;
                        return RedirectToAction("Appointment", "Appointment");
                    }
                    else if (patient != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Username, false); // Authenticate the user
                        // Patient login logic
                        Session["PatientID"] = patient.PatientID.ToString();
                        Session["Username"] = patient.Username;
                        return RedirectToAction("Appointment", "Appointment");
                    }
                    else
                    {
                        ModelState.AddModelError("RegistrationModel.Username", "Invalid username or password.");
                        return RedirectToAction("Index");
                    }
                }
            }
            return View("Index");
        }
    }
}