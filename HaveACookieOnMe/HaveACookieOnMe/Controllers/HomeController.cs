using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HaveACookieOnMe.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DoGiveCookie(string Type, string Recipient, string Message, string Charity)
        {
            

            return RedirectToAction("Index");
        }
    }
}