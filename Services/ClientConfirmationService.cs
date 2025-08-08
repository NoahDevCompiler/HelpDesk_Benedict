using Azure.Core;
using HelpDesk_Benedict.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using System;

namespace HelpDesk_Benedict.Services
{
    public class ClientConfirmationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailSender _emailSender;
        public ClientConfirmationService(UserManager<ApplicationUser> userManager, IEmailSender emailSender) {
            _userManager = userManager;
            _emailSender = emailSender;

        }

        public async Task SendConfirmationEmailAsync(string email, string confirmationLink) {
            var message = $"Bitte bestätigen Sie Ihre Email: <a href='{confirmationLink}'>Hier klicken</a>";
            await _emailSender.SendEmailAsync(email, "Email Bestätigung", message);
        }
    }
}
