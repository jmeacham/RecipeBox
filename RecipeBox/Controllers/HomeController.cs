
using RecipeBox.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RecipeBox.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "A place to create and store your recipes.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactViewModel model, string message)
        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    MailMessage msg = new MailMessage();
                    msg.To.Add("meach529@yahoo.com");
                    msg.From = new MailAddress(model.Email);
                    msg.Subject = model.Subject;
                    msg.Body = model.Message;
                    SmtpClient client = new SmtpClient();
                    client.Host = "smtp.mail.yahoo.com";
                    client.Port = 465;
                    client.EnableSsl = true;
                    client.Send(msg);
                }
                catch (Exception)
                {
                    return View("Error");
                }

             }
            ViewBag.ContactMessage = "Thanks, we got your message!";
            return PartialView("_ContactMessage"); 
        }
    }
}