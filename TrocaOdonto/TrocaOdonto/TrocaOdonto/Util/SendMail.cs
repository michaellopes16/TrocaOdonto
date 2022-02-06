using MailKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Text;

namespace TrocaOdonto.Util
{
    public class SendMail
    {

        private readonly MimeMessage mailMessage;
        public static string VALIDATION_COD;

        public SendMail()
        {
            VALIDATION_COD = string.Empty;
            mailMessage = new MimeMessage();
        }

        public bool SendForgotMailToUser(string emailto, string userName)
        {
            try
            {
                CreateMail(emailto, userName);
                using (SmtpClient smtpClient = new SmtpClient())
                {
                    //  | Protocol | Standard Port | SSL Port |
                    //  |:------:  |:-----------:  |:------:  |
                    //  | SMTP     | 25 or 587     | 465      |
                    //  | POP3     | 110           | 995      |
                    //  | IMAP     | 143           | 993      |
                    smtpClient.CheckCertificateRevocation = false;
                    smtpClient.ServerCertificateValidationCallback = (sender, certificate, chain, errors) => true;
                    smtpClient.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);// smtp.gmail.com - 465, imap.gmail.com - 993, smtp.office365.com
                    var _ = smtpClient.AuthenticationMechanisms.Remove("XOAUTH2");
                    smtpClient.Authenticate("trocaodontohelper@gmail.com", "09448967403mlb");
                    var a = smtpClient.Send(mailMessage);
                    smtpClient.Disconnect(true);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Erro: {0}", ex.Message));
                return false;
            }

        }
        public string ValidationCode()
        {
            Random rnd = new Random();
            VALIDATION_COD = string.Empty;
            for (int i = 0; i < 4; i++)
            {
                VALIDATION_COD = string.Concat(VALIDATION_COD, rnd.Next(0, 9).ToString());
            }
            return VALIDATION_COD;
        }

        private void CreateMail(string emailto, string userName)
        {
            mailMessage.From.Add(new MailboxAddress("Troca Odonto", "trocaodontohelper@gmail.com"));
            mailMessage.To.Add(new MailboxAddress(userName, emailto));
            mailMessage.Subject = "Recuperação de senha";
            mailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = "<h2> Olá " + userName + "! :) </h2><p><h3> Tais esquecido que só a gota em? hehehe. Presta atenção agora viu? " +
                       "Insira o código ai de baixo no app pra poder criar uma nova senha. <h3></p>  " +
                       "<p><h2> Seu código é: " + ValidationCode() + "</h2></p>" +
                       "<br>" +
                       "<p>At.te: Equipe Troca Odonto! :)  </p>"
            };
        }

    }
}
