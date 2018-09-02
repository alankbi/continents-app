using System;
using System.Net.Mail;
using Continents.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(MailSender))]
namespace Continents.Droid
{
    public class MailSender : IEmailSender
    {
        public void SendEmail(string subject, string body)
        {
            MailMessage mm = new MailMessage("continentsmobilecontact@gmail.com", "custserv@continents.us");
            mm.Subject = subject;
            mm.Body = body;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.UseDefaultCredentials = false;
            // to work, the email below must have security settings edited to allow access from less secure apps 
            smtp.Credentials = new System.Net.NetworkCredential("continentsmobilecontact@gmail.com", "*****");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.Send(mm);
        }
    }
}
