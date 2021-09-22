using LuizaLabs.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuizaLabs.Service.Email
{
    public class EmailService : IEmailService
    {
        //public async void EnviaEmail(UserModel userModel)
        //{
        //    var html = await MontaHtml(userModel.Id);
        //    var email = new MimeMessage();
        //    email.From.Add(MailboxAddress.Parse(_appConfig.FromEmailAdress));
        //    email.To.Add(MailboxAddress.Parse(usuario.Email));
        //    email.Subject = "Luizalabs - Alteração de senha";
        //    email.Body = new TextPart(TextFormat.Html) { Text = html };

        //    using var smtp = new SmtpClient();
        //    smtp.Connect(_appConfig.SmtpHost, Convert.ToInt32(_appConfig.SmtpPort), SecureSocketOptions.StartTls);
        //    smtp.Authenticate(_appConfig.SmtpUser, _appConfig.SmtpPass);
        //    smtp.Send(email);
        //    smtp.Disconnect(true);
        //}

        //private async Task<string> MontaHtml(int idUsuario)
        //{
        //    var notificacao = await _repoNotificacao.PesquisarPor(x => x.IdNotificacao == Convert.ToInt32(_appConfig.IdNotificacao));
        //    var html = notificacao.FirstOrDefault().Html.Replace("[URLRECUPERAR]", _appConfig.UrlFront + idUsuario);
        //    return html;
        //}
    }
}
