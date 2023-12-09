﻿using MailKit.Net.Smtp;
using MailKit.Security;
using PharmaFinder.Core.DTO;
using PharmaFinder.Core.Service;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using PharmaFinder.Api.Settings;

namespace PharmaFinder.Infra.Service
{
    public class EmailService: IEmailService
    {
        private readonly EmailConfiguration _emailConfig;
        public EmailService(IOptions<EmailConfiguration> emailConfig)
        {
            _emailConfig = emailConfig.Value;
        }
        public void SendEmail(SendEmailDto emailDto)
        {
            var email = new MimeMessage
            {
                Subject = emailDto.Subject,
                To = { MailboxAddress.Parse(emailDto.To) },
                Body = new TextPart(TextFormat.Html)
                {
                    Text = emailDto.Html
                },
                From = { MailboxAddress.Parse(_emailConfig.From) }
            };
            using (var smtp = new SmtpClient())
            {
                smtp.Connect(_emailConfig.Host, _emailConfig.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_emailConfig.From, _emailConfig.Password);
                var response = smtp.Send(email);
                smtp.Disconnect(true);
            }
        }

    }
}