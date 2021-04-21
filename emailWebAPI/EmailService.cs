using System;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;

namespace emailWebAPI
{
    public class EmailService
    {
        private SmtpClient smtpClient;

        public EmailService()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            var config = builder.Build();

            this.smtpClient = new SmtpClient(config["Smtp:Host"]);
            this.smtpClient.EnableSsl = true;
            this.smtpClient.Port = int.Parse(config["Smtp:Port"]);
            this.smtpClient.Credentials = new NetworkCredential(config["Smtp:Email"], config["Smtp:Password"]);
        }

        public bool SendEmail(string from, string to, string subject, string body)
        {
            bool valid = CheckRecipientsValidity(to);
            bool success;

            if (valid)
            {
                MailMessage mm = new MailMessage(from, to, subject, body);
                this.smtpClient.Send(mm);
                success = true;
            }
            else
            {
                success = false;
            }

            return success;
        }

        /*Verify that the recipients string is a comma-separated string that contains emails*/
        private bool CheckRecipientsValidity(string recipients)
        {
            bool valid = true;
            string[] emails = recipients.Split(',');
            string regexp = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            
            foreach (string email in emails)
            {
                if(!Regex.IsMatch(email, regexp, RegexOptions.IgnoreCase)) {
                    valid = false;
                }
            }


            return valid;
        }
    }
}
