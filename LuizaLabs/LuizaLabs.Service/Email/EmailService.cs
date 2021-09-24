using LuizaLabs.Domain.User;
using LuizaLabs.Shared.Extensions;
using LuizaLabs.Shared.Settings;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LuizaLabs.Service.Email
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _emailSettings;

        public EmailService(IOptions<EmailSettings> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendPasswordChange(UserModel userModel)
        {
            var variaveis = new Dictionary<string, string>();
            variaveis.Add("nome", userModel.Name);
            var html = StringExtensions.ReadHtml("recuperacao_senha.html", variaveis);
            await SendEmail(userModel, html, "Luizalabs - Alteração de senha");
        }

        private async Task SendEmail(UserModel userModel, string html, string subject)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_emailSettings.FromEmailAdress));
            email.To.Add(MailboxAddress.Parse(userModel.Email));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = html };
            var smtp = new SmtpClient();
            smtp.Connect(_emailSettings.SmtpHost, Convert.ToInt32(_emailSettings.SmtpPort), SecureSocketOptions.StartTls);
            smtp.Authenticate(_emailSettings.SmtpUser, _emailSettings.SmtpPass);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }

    }
}
