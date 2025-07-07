using System.Net;
using System.Net.Mail;

namespace SendEmailApi.Services
{
    public class EmailService
    {
        private readonly SmtpClient _smtpClient;

        public EmailService(IConfiguration configuration)
        {
            _smtpClient = new SmtpClient
            {
                Host = configuration["SmtpSettings:Host"],
                Port = int.Parse(configuration["SmtpSettings:Port"]),
                EnableSsl = true,
                Credentials = new NetworkCredential(
                    configuration["SmtpSettings:User"],
                    configuration["SmtpSettings:Password"]
                )
            };
        }

        public async Task SendEmail(EmailRequest emailRequest)
        {
            var mailMessage = new MailMessage
            {
                From = new MailAddress(emailRequest.Anonymous ? "anonymous@example.com" : emailRequest.SenderEmail, emailRequest.SenderName),
                Subject = emailRequest.Subject,
                Body = emailRequest.Message,
                IsBodyHtml = true
            };

            mailMessage.To.Add(emailRequest.To);

            await _smtpClient.SendMailAsync(mailMessage);
        }
    }
}