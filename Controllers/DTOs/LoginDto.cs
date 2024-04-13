using System.ComponentModel.DataAnnotations;
using Microsoft.OpenApi.Models;

namespace StockWebApp.Controllers.DTOs
{
    public class LoginDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }

}
