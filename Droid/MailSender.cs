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
            MailMessage mm = new MailMessage("orsonfakeemail@gmail.com", "orsonfakeemail@gmail.com");
            mm.Subject = subject;
            mm.Body = body;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("orsonfakeemail@gmail.com", "oronsonon");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.Send(mm);
        }
    }
}
