using Microsoft.EntityFrameworkCore;

using StockWebApp.Controllers.DTOs;
using StockWebApp.Data;
using StockWebApp.Helper;
using StockWebApp.Interfaces;
using StockWebApp.Models;

namespace StockApp.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDbContext _context;
        public StockRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Stock> CreateAsync(Stock stockModel)
        {
            await _context.Stocks.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<Stock?> DeleteAsync(int id)
        {
            var existingStock = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);

            if (existingStock == null)
            {
                return null; //or not found, but never return status code, any where other than the controller.
            }

            _context.Stocks.Remove(existingStock);
            await _context.SaveChangesAsync();
            return existingStock;
        }

        /*public async Task<List<Stock?>> GetAllAsync()
        {
            return await _context.Stocks.ToListAsync();
        }*/

        public async Task<List<Stock?>> GetAllAsync(QueryObject query)
        {
            var stock = _context.Stocks.AsQueryable();

            // filtering
            if (!string.IsNullOrEmpty(query.Symbol))
            {
                stock = stock.Where(s => s.Symbol.Contains(query.Symbol));
            }
            if (!string.IsNullOrEmpty(query.CompanyName))
            {
                stock = stock.Where(s => s.CompanyName.Contains(query.CompanyName));
            }
            // sorting 
            if (!string.IsNullOrEmpty(query.SorrtBy))
            {
                if (query.SorrtBy.Equals("Symbol", StringComparison.OrdinalIgnoreCase))
                {
                    stock = (bool)query.IsDecending ? stock.OrderByDescending(c => c.Symbol) : stock.OrderBy(c => c.Symbol);
                }
            }

            //Pagination
            var skippNumber = (query.PageNumber - 1) * query.PageSize;



            return await stock.Skip(skippNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await _context.Stocks.Include(c => c.Comments).FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<bool> StockExist(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockDto)
        {
            var existingStock = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);

            if (existingStock == null)
            {
                return null; //or not found, but never return status code, any where other than the controller.
            }
            //else start updating

            existingStock.Symbol = stockDto.Symbol;
            existingStock.CompanyName = stockDto.CompanyName;
            existingStock.Purchase = stockDto.Purchase;
            existingStock.LastDiv = stockDto.Lastdiv;
            existingStock.Industry = stockDto.Industry;
            existingStock.MarketCap = stockDto.MarketCap;

            await _context.SaveChangesAsync();
            return existingStock;

        }

       /* public Task<bool> StockExist(int id)
        {
            return await _context.Stocks.Any(x => x.Id == id);
        }*/

        public Task<Stock> UpdateAsync()
        {
            throw new NotImplementedException();
        }

       
    }
}
