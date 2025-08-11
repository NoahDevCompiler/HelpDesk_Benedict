using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using HelpDesk_Benedict.Models;
using System.Net.Mail;
using Microsoft.Extensions.Options;

namespace HelpDesk_Benedict.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly SmtpSettings _smtpSettings;

        public EmailSender(IOptions<SmtpSettings> smtpOptions)
        {
            _smtpSettings = smtpOptions.Value;
        }   
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
                var  client = new SmtpClient(_smtpSettings.Host, _smtpSettings.Port)
                {
                    Credentials = new System.Net.NetworkCredential(_smtpSettings.UserName, _smtpSettings.Password),
                    EnableSsl = _smtpSettings.EnableSsl
                };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_smtpSettings.FromEmail, _smtpSettings.FromName),
                Subject = subject,
                Body = htmlMessage,
                IsBodyHtml = true,
            };
            mailMessage.To.Add(email);

            await client.SendMailAsync(mailMessage);
        }
    }
}
