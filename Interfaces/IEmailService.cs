using StockWebApp.Controllers.DTOs.Email;

namespace StockWebApp.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailRegistration(EmailDto request);

    }
}
