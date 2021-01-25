using System;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace IntegrationAdapter.SMTPServiceSupport
{
    public static class SMTPNotificationSender
    {
        public static void SendMessage(string from, string password, string to, string subject, string body)
        {
            if (!(CheckIfValidEmail(from) && CheckIfValidEmail(to)))
            {
                NotifyAboutErrorInCommunication("Message could not be sent because the email format was incorrect.");
                return;
            }

            string emailDomain = GetSMTPHostBasedOnEmail(from);
            if (emailDomain == null)
            {
                NotifyAboutErrorInCommunication("Domain in email " + from + " was not recognized or does not exist.");
                return;
            }

            MailMessage message = new MailMessage(from, to, subject, body);
            SmtpClient smtpClient = CreateSMTPClient(from, password, emailDomain);

            try
            {
                smtpClient.Send(message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        private static void NotifyAboutErrorInCommunication(string messageError)
        {
            SmtpClient smtpClient = CreateSMTPClient(Environment.GetEnvironmentVariable("HospitalEmail"),
                                                     Environment.GetEnvironmentVariable("HospitalEmailPassword"),
                                                     GetSMTPHostBasedOnEmail(Environment.GetEnvironmentVariable("HospitalEmail")));
            MailMessage message = new MailMessage(Environment.GetEnvironmentVariable("HospitalEmail"),
                                                  Environment.GetEnvironmentVariable("HospitalEmail"),
                                                  "Error in communication",
                                                  messageError);
            try
            {
                smtpClient.Send(message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        private static bool CheckIfValidEmail(string email)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(email);
        }

        private static SmtpClient CreateSMTPClient(string from, string password, string emailDomain)
        {
            return new SmtpClient
            {
                Host = emailDomain,
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(from, password)
            };
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
