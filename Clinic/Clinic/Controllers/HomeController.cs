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
        public ActionResult Login(RegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                using (ClinicEntities db = new ClinicEntities())
                {
                    // Check if the provided username and password match a Patient record.
                    var patient = db.Patients.FirstOrDefault(p => p.Username == model.Patient.Username && p.Password == model.Patient.Password);

                    // Check if the provided username and password match a Doctor record.
                    var doctor = db.Doctors.FirstOrDefault(d => d.Username == model.Doctor.Username && d.Password == model.Doctor.Password);

                    if (patient != null)
                    {
                        // The provided credentials belong to a patient. You can log them in and redirect accordingly.
                        // For example, set an authentication token and redirect to a patient dashboard.
                        // Replace "YourPatientDashboard" with the actual route name or URL for the patient dashboard.
                        // You can use a library like ASP.NET Identity for user authentication.
                        // Example:
                        // SignInManager.SignInAsync(patient, false, false);
                        return RedirectToAction("YourPatientDashboard");
                    }
                    else if (doctor != null)
                    {
                        // The provided credentials belong to a doctor. You can log them in and redirect accordingly.
                        // For example, set an authentication token and redirect to a doctor dashboard.
                        // Replace "YourDoctorDashboard" with the actual route name or URL for the doctor dashboard.
                        // You can use a library like ASP.NET Identity for user authentication.
                        // Example:
                        // SignInManager.SignInAsync(doctor, false, false);
                        return RedirectToAction("YourDoctorDashboard");
                    }
                    else
                    {
                        // Neither a patient nor a doctor with matching credentials was found.
                        // You can handle this case, for example, by displaying an error message.
                        ModelState.AddModelError("", "Invalid username or password");
                    }
                }
            }

            // If the model state is not valid or if no valid user is found, return to the login page.
            return View(model);
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