using StockWebApp.Controllers.DTOs;
using StockWebApp.Helper;
using StockWebApp.Models;

namespace StockWebApp.Interfaces
{
    public interface IStockRepository
    {
        Task<Stock>CreateAsync(Stock stockModel);

        Task<Stock> GetByIdAsync(int Id);
        Task<List<Stock?>> GetAllAsync(QueryObject query);
        Task<Stock> DeleteAsync(int id);
        Task<Stock> UpdateAsync(int id, UpdateStockRequestDto updateDto);
        Task<bool> StockExist(int id);



    }
}
