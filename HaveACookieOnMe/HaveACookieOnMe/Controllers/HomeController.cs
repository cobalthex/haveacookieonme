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

        [HttpGet]
        public ActionResult Address(int Id)
        {
            return View("SupplyAddress", Id);
        }

        [HttpPost]
        public ActionResult GiveCookie(Models.RequestModel Request)
        {

            return RedirectToAction("Index");
        }
    }
}