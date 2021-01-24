using System;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace MedicineProcurement.Service
{
    public static class SMTPNotificationSender
    {
        public static void SendMessageToAllPharmacies(string to, string subject, string body)
        {
            MailMessage message = new MailMessage(Environment.GetEnvironmentVariable("HospitalEmail"), to, subject, body);

            SmtpClient smtpClient = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(Environment.GetEnvironmentVariable("HospitalEmail"),
                                                    Environment.GetEnvironmentVariable("HospitalEmailPassword"))
            };

            try
            {
                smtpClient.Send(message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public static void SendMessage(string from, string password, string to, string subject, string body)
        {
            MailMessage message = new MailMessage(from, to, subject, body);

            string emailDomain = GetSMTPHostBasedOnEmail(from);
            if (emailDomain == null)
            {
                return;
            }

            SmtpClient smtpClient = new SmtpClient
            {
                Host = emailDomain,
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(from, password)
            };

            try
            {
                smtpClient.Send(message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        private static string GetSMTPHostBasedOnEmail(string email)
        {
            Regex domainRegex = new Regex(@"(?<=@)[^.]+(?=\.)");
            string domain = domainRegex.Match(email).Value;

            switch (domain)
            {
                case "gmail":
                    return "smtp.gmail.com";
                case "outlook":
                    return "smtp.live.com";
                case "hotmail":
                    return "smtp.live.com";
                case "yahoo":
                    return "smtp.mail.yahoo.com";
                default:
                    return null;
            }
        }
    }
}
