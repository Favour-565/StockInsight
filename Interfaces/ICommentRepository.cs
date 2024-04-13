using StockWebApp.Models;

namespace StockWebApp.Interfaces
{
    public interface ICommentRepository
    {
        Task CreateCommentAsync(Models.Comment comment);
        Task<Models.Comment> GetByIdAsync(int id);
        Task<List<Models.Comment>> GetAllAsync();
        Task<Models.Comment> CreateAsync(Models.Comment comment);

    }
}
