using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net.Mail;
using System.Net;

namespace Helping_Hands_2._0.Models
{
    public class EmailService : IEmailSender
    {
        private readonly SmtpClient _smtpClient;

        public EmailService(IConfiguration configuration)
        {
            var smtpServer = configuration["SmtpSettings:Server"];
            var smtpPort = int.Parse(configuration["SmtpSettings:Port"]);
            var smtpUsername = configuration["SmtpSettings:Username"];
            var smtpPassword = configuration["SmtpSettings:Password"];

            _smtpClient = new SmtpClient(smtpServer)
            {
                Port = smtpPort,
                Credentials = new NetworkCredential(smtpUsername, smtpPassword),
                EnableSsl = true
            };
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            var mailMessage = new MailMessage
            {
                From = new MailAddress("cewukamva@gmail.com"),
                Subject = subject,
                Body = message,
                IsBodyHtml = true
            };
            mailMessage.To.Add(email);

            return _smtpClient.SendMailAsync(mailMessage);
        }
    }

}
