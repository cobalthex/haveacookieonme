using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;

namespace HaveACookieOnMe.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CookieSent()
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
            if (Request.IsRecipientAnEmail)
            {
                try
                {
                    MailMessage mailMsg = new MailMessage();

                    // To
                    mailMsg.To.Add(new MailAddress(Request.Recipient));

                    // From
                    mailMsg.From = new MailAddress("nomore@haveacookieon.me", "(No Reply) Have a Cookie, on Me");

                    // Subject and multipart/alternative Body
                    mailMsg.Subject = "subject";
                    string text = "You have a cookie waiting for you! To claim it, please let us find you by going to http://haveacookieon.us/address/1.";
                    string html = RenderRazorViewToString("~/Views/Email/SupplyAddress.cshtml", null);
                    mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, System.Net.Mime.MediaTypeNames.Text.Plain));
                    mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, System.Net.Mime.MediaTypeNames.Text.Html));

                    // Init SmtpClient and send
                    SmtpClient smtpClient = new SmtpClient("smtp.sendgrid.net", Convert.ToInt32(587));
                    System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("cobalthex@haveacookieon.us", "1ceduJukoBukoDuko41");
                    smtpClient.Credentials = credentials;

                    smtpClient.Send(mailMsg);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                return RedirectToAction("CookieSent");
            }

            return RedirectToAction("Index");
        }

        public string RenderRazorViewToString(string viewName, object model)
        {
            ViewData.Model = model;
            using (var sw = new System.IO.StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }
    }
}