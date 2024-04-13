using System.ComponentModel.DataAnnotations;

namespace StockWebApp.Controllers.DTOs.Account
{
    public class RegisterDto
    {
        [Required]
        public string? Username { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string? Password { get; set; }
    }
}
