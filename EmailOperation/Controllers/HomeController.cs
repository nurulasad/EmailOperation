using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace EmailOperation.Controllers
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

        public string SendMail(MailConfig config)
        {
            MailMessage m = new MailMessage();
            SmtpClient sc = new SmtpClient();

            m.From = new MailAddress(config.from, config.from);
            //m.To.Add(new MailAddress("nurulasad@gratex.com.au", "Display name To"));

            m.To.Add(new MailAddress(config.to, config.to));

            m.Subject = config.subject;
            m.Body = config.body;

            if (config.useWebConfigMailServer == bool.FalseString)
            {
                sc.Host = config.host;
                sc.Port = int.Parse(config.port);
            }
            

            if (config.useCredential == bool.TrueString)
            {
                sc.Credentials = new System.Net.NetworkCredential("Gratex\\svc.orq2email", "yUggQY1LbRA9PQJDFcOQ");
            }
            
            if (config.useSSL == bool.TrueString)
            {
                sc.EnableSsl = true; // runtime encrypt the SMTP communications using SSL
            }

            try
            {
                sc.Send(m);
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            
            

            return "Email sent";
        }
    }

    public class MailConfig
    {
        public string from { get; set; }
        public string to { get; set; }
        public string subject { get; set; }
        public string body { get; set; }
        public string host { get; set; }
        public string port { get; set; }


        public string useWebConfigMailServer { get; set; }
        public string useSSL { get; set; }
        public string useCredential { get; set; }

        public string username { get; set; }
        public string password { get; set; }

    }
}