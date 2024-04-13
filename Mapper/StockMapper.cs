using StockWebApp.Controllers.DTOs.Account;
using StockWebApp.Models;

namespace StockWebApp.Mapper
{
    public static class StockMapper
    {
        public static Stock ToStockFromCreateDTO(this CreateStockDTO stockDto)
        {

            return new Stock
            {
                Symbol = stockDto.Symbol,
                CompanyName = stockDto.CompanyName,
                Purchase = stockDto.Purchase,
                LastDiv = stockDto.Lastdiv,
                Industry = stockDto.Industry,
                MarketCap = stockDto.MarketCap
            };

        }

        public static Stock ToStock(this Stock stockDto)
        {

            return new Stock
            {
                Id = stockDto.Id,
                Symbol = stockDto.Symbol,
                CompanyName = stockDto.CompanyName,
                Purchase = stockDto.Purchase,
                LastDiv = stockDto.LastDiv,
                Industry = stockDto.Industry,
                MarketCap = stockDto.MarketCap
            };

        }
        
    }
}