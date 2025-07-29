using AdvancedProgramming.Mvc.Helpers;
using AdvancedProgramming.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdvancedProgramming.Mvc.Controllers
{
    public class LoginController : Controller
    {
        private UserRepository userRepository = new UserRepository();
        private SessionState session;

       
        // GET: Login

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string username, string password)
        {
            var user = userRepository.GetUser(username, password);
            if (user != null)
            {
                var session = new SessionState(this.Session);
                session.CurrentUser = user;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid username or password.";
                return View();
            }
        }
    }
}