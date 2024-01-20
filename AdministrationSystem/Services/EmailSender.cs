using AdministrationSystem.Data;
using AdministrationSystem.Interfaces;
using AdministrationSystem.Models;
using System.Net;
using System.Net.Mail;

namespace AdministrationSystem.Services
{
    public class EmailSender : IEmailSender
    {

        private readonly Admin admin;

        public EmailSender(
            Admin admin
            )
        {
            this.admin = admin;
        }

        public Task SendEmailAsync(string email, string subject, string body)
        {
            Admin adminSettings = admin.GetAdmin();
            string myEmail = adminSettings.Email;
            string myPassword = adminSettings.Password;

            var client = new SmtpClient("smtp-mail.outlook.com", 587)
            {
                EnableSsl = true,
                Credentials = new NetworkCredential(myEmail, myPassword)
            };

            return client.SendMailAsync(
                new MailMessage(
                from: myEmail,
                to: email,
                subject,
                body
                ));
        }
    }
}
