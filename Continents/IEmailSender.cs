using System;
namespace Continents
{
    public interface IEmailSender
    {
        void SendEmail(string subject, string body);
    }
}
