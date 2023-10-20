using Clinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        [Authorize(Roles = "Doctor, Patient")]
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
                        // Doctor login logic
                        Session["DoctorID"] = doctor.DoctorID.ToString();
                        Session["Username"] = doctor.Username;
                        return RedirectToAction("Create", "Appointment");
                    }
                    else if (patient != null)
                    {
                        // Patient login logic
                        Session["PatientID"] = patient.PatientID.ToString();
                        Session["Username"] = patient.Username;
                        return RedirectToAction("Create", "Appointment");
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

        public ActionResult UserDashBoard()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}