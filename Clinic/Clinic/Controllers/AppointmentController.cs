using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

[AuthorizeWithSession]
public class AppointmentController : Controller
{
    // GET: Appointment
    public ActionResult Index()
    {
        return View();
    }

    // GET: /Appointment/Create
    [Authorize(Roles = "Doctor, Patient")]
    public ActionResult Create()
    {
        // Add the logic for the Create action here
        return View("Create"); // Optionally, specify the view name
    }
}

public class AuthorizeWithSessionAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (context.HttpContext.Session == null || context.HttpContext.Session["DoctorID"] == null || context.HttpContext.Session["PatientID"] == null)
        {
            context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Login" }));
        }

        base.OnActionExecuting(context);
    }
}
