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
        public ActionResult Login(RegistrationModel objUser)
        {
            if (ModelState.IsValid)
            {
                using (ClinicEntities db = new ClinicEntities())
                {
                    var obj = db.Patients.Where(a => a.Username.Equals(objUser.Patient.Username) && a.Password.Equals(objUser.Patient.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.UserId.ToString();
                        Session["UserName"] = obj.UserName.ToString();
                        return RedirectToAction("UserDashBoard");
                    }
                }
            }
            return View(objUser);
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