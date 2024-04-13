using StockWebApp.Models;

namespace StockWebApp.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
