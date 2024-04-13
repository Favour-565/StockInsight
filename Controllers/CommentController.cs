using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockWebApp.Controllers.DTOs.Account;
using StockWebApp.Interfaces;
using StockWebApp.Mapper;
using System.Threading.Tasks;
using StockWebApp.Comment;

namespace StockWebApp.Controllers.DTOs
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IStockRepository _stockRepository;

        public CommentController(ICommentRepository commentRepository, IStockRepository stockRepository)
        {
            _commentRepository = commentRepository;
            _stockRepository = stockRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CreateCommentDTO commentDto)
        {
            var comment = CommentMapper.ToCommentFromCreateCommentDTO(commentDto);
            await _commentRepository.CreateAsync(comment);
            return Ok(comment);
        }
    }
}