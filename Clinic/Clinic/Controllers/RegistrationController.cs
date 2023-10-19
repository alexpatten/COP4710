using Clinic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
                ClinicEntities db = new ClinicEntities();

                if (model.SelectedUserType == "Doctor") // Process Doctor registration
                {
                    if (db.Doctors.Any(d => d.Username == model.Doctor.Username))
                    {
                        ModelState.AddModelError("Doctor.Username", "Username is already taken.");
                    }
                    else if (db.Doctors.Any(d => d.Email == model.Doctor.Email))
                    {
                        ModelState.AddModelError("Doctor.Email", "Email is already in use.");
                    }
                    else if (!model.Doctor.Email.Contains("@"))
                    {
                        ModelState.AddModelError("Doctor.Email", "Invalid email address.");
                    }
                    else
                    {
                        db.Doctors.Add(model.Doctor);
                        db.SaveChanges();
                    }
                }
                else if (model.SelectedUserType == "Patient") // Process Patient registration
                {
                    if (db.Patients.Any(d => d.Username == model.Patient.Username))
                    {
                        ModelState.AddModelError("Patient.Username", "Username is already taken.");
                    }
                    else if (db.Patients.Any(d => d.Email == model.Patient.Email))
                    {
                        ModelState.AddModelError("Patient.Email", "Email is already in use.");
                    }
                    else if (!model.Patient.Email.Contains("@"))
                    {
                        ModelState.AddModelError("Patient.Email", "Invalid email address.");
                    }
                    else
                    {
                        db.Patients.Add(model.Patient);
                        db.SaveChanges();
                    }
                }
                else
                {
                    if (db.Doctors.Any(d => d.Username == model.Doctor.Username))
                    {
                        ModelState.AddModelError("Doctor.Username", "Username is already taken.");
                    }
                    else if (db.Doctors.Any(d => d.Email == model.Doctor.Email))
                    {
                        ModelState.AddModelError("Doctor.Email", "Email is already in use.");
                    }
                    else if (!model.Doctor.Email.Contains("@"))
                    {
                        ModelState.AddModelError("Doctor.Email", "Invalid email address.");
                    }
                    else
                    {
                        db.Doctors.Add(model.Doctor);
                        db.SaveChanges();
                    }
                }
            }

            return View("Index");
        }
    }
}