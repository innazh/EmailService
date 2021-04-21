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
        private string emailSender;

        public EmailService()
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            var config = builder.Build();

            this.smtpClient = new SmtpClient(config["Smtp:Host"]);
            this.smtpClient.EnableSsl = true;
            this.smtpClient.Port = int.Parse(config["Smtp:Port"]);
            this.smtpClient.Credentials = new NetworkCredential(config["Smtp:Email"], config["Smtp:Password"]);

            this.emailSender = config["Smtp:Email"];
            
        }

        /*Sends email with given subject and body to the recipients provided using smtp client*/
        public bool SendEmail(string subject, string body, string[] recipients)
        {
            bool valid = CheckRecipientsValidity(recipients);
            bool success=true;

            if (valid)
            {
                //Construct the email.
                var mailMessage = new MailMessage()
                {
                    From = new MailAddress(this.emailSender),
                    Subject = subject,
                    Body = body
                };
                //Add recipients
                foreach (string r in recipients)
                {
                    mailMessage.To.Add(r);
                }

                //Console.WriteLine("List of recipients:");
                //Console.WriteLine(mailMessage.To);
                try
                {
                    this.smtpClient.Send(mailMessage);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    success = false;
                }
            }
            else
            {
                success = false;
            }

            return success;
        }

        /*Verify that the recipients array contains emails*/
        private bool CheckRecipientsValidity(string[] recipients)
        {
            bool valid = true;
            string regexp = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            
            foreach (string email in recipients)
            {
                if(!Regex.IsMatch(email, regexp, RegexOptions.IgnoreCase)) {
                    valid = false;
                }
            }

            //Console.WriteLine("CheckRecipientsValidity=" + valid.ToString());
            return valid;
        }
    }
}
