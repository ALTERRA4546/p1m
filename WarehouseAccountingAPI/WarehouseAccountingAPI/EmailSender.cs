using System.Net.Mail;
using System.Net;

namespace WarehouseAccountingAPI
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }

    public class EmailSender : IEmailSender
    {
        private readonly SmtpClient _smtpClient;

        public EmailSender()
        {
            _smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("non@mail.ru", "loh"),
                EnableSsl = true,
            };
        }

        public Task SendEmailAsync(string email, string subject, string message)
        {
            var mailMessage = new MailMessage
            {
                From = new MailAddress("your-email@gmail.com"),
                Subject = subject,
                Body = message,
                IsBodyHtml = true,
            };

            mailMessage.To.Add(email);
            return _smtpClient.SendMailAsync(mailMessage);
        }
    }
}
