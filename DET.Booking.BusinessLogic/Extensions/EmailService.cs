﻿using System.Net.Mail;
using System.Net;
using SystemSmtpClient = System.Net.Mail.SmtpClient;

namespace DET.Booking.BusinessLogic.Extensions
{
    public class EmailService
    {
        private readonly DET.Booking.Extensions.CustomValuesConfiguration _customValuesConfiguration;

        public EmailService(DET.Booking.Extensions.CustomValuesConfiguration? customValuesConfiguration)
        {
            _customValuesConfiguration = customValuesConfiguration;
        }

        public async Task EnviarCorreoAsync(string destinatario, string asunto, string mensaje)
        {
            var EmailConfig = _customValuesConfiguration.GetCustomValueByName("EmailConfiguration");

            var smtpServer = EmailConfig.Values["smtpServer"];
            var smtpPort = EmailConfig.Values["smtpPort"];
            var smtpUser = EmailConfig.Values["smtpUser"];
            var smtpPass = EmailConfig.Values["smtpPass"];


            using (var client = new SystemSmtpClient(smtpServer, Convert.ToInt32(smtpPort)))
            {
                client.Credentials = new NetworkCredential(smtpUser, smtpPass);
                client.EnableSsl = true;

                var mail = new MailMessage
                {
                    From = new MailAddress(smtpUser),
                    Subject = asunto,
                    Body = mensaje,
                    IsBodyHtml = true
                };
                mail.To.Add(destinatario);

                await client.SendMailAsync(mail);
            }
        }
    }
}
