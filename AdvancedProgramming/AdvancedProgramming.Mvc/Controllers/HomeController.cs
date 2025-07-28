using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdvancedProgramming.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Set()
        {
            Guid sessionId = SessionManager.GetOrCreateSessionId(Request, Response);
            SessionManager.SetSessionData(sessionId, "Prueba Jose Pablo Salgado Herrera");

        return Content("Sesión guardada en el servidor");
        }

        public ActionResult Get()
        {
            Guid sessionId = SessionManager.GetOrCreateSessionId(Request, Response);
            string userData = SessionManager.GetSessionData(sessionId);

        return Content("Datos de la sesión actual: " + (userData ?? "Vacío"));
        }
    }
}
