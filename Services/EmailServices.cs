using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Routing.Template;
using Org.BouncyCastle.Security;
using StockWebApp.Controllers.DTOs.Email;
using StockWebApp.Interfaces;
using MailKit;

namespace StockWebApp.Services
{
    public class EmailServices : IEmailService
    {
        private readonly IConfiguration _config;

        public EmailServices(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendEmailRegistration(EmailDto request)
        {
            string body = PopulateRegisterEmail(request.UserName, request.Otp);
            var email = new MimeMessage();

            email.From.Add(MailboxAddress.Parse(_config["EmailSettings:EmailUserName"]));
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = request.Subject;
            /*email.Body = new TextPart(TextFormat.Html) { Text = request.Body };*/
            var builder = new BodyBuilder();
            builder.HtmlBody = body;
            email.Body = builder.ToMessageBody();

            using var smtp = new SmtpClient();

            smtp.Connect(_config["EmailSettings:EmailHost"], int.Parse(_config["EmailSettings:EmailPort"]), SecureSocketOptions.StartTls);
            smtp.Authenticate(_config["EmailSettings:EmailUserName"], _config["EmailSettings:EmailPassword"]);

            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }

        private string PopulateRegisterEmail(string UserName, string Otp)
        {
            string body = string.Empty;
            string filePath = Directory.GetCurrentDirectory() + @"\Template\RegistrationTemplate.html";

            using (StreamReader reader = new StreamReader(filePath))
            {
                body = reader.ReadToEnd();
            }

            body = body.Replace("{UserName}", UserName);
            body = body.Replace("{Otp}", Otp);
            return body;
        }
    }
}