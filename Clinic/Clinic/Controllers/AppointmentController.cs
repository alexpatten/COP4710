using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

[Authorize]
public class AppointmentController : Controller
{
    // GET: /Appointment
    [Authorize]
    [Route("Home/Appointment")]
    public ActionResult Appointment()
    {
        return View("Appointment"); // Optionally, specify the view name
    }
}