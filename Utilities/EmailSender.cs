using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using SendGrid.Helpers.Mail;
using SendGrid;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace MVC.Utilities
{
    public class EmailSender : IEmailSender
    {

        public string SendGridSecret { get; set; }

        public EmailSender(IConfiguration _config)
        {
            SendGridSecret = _config.GetValue<string>("SendGrid:SecretKey");
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //logic to send email

            var client = new SendGridClient(SendGridSecret);

            var from = new MailAddress("hello@dotnetmastery.com", "Bulky Book");
            var to = new MailAddress(email);
            var message = MailHelper.CreateSingleEmail(from, to, subject, "", htmlMessage);

            return client.SendEmailAsync(message);

        }
    }