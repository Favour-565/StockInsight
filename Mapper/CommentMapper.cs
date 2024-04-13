using StockWebApp.Comment;
using StockWebApp.Controllers.DTOs.Account;
using StockWebApp.Models;

namespace StockWebApp.Mapper
{
    public class CommentMapper
    {
        public static Models.Comment ToCommentFromCreateCommentDTO(CreateCommentDTO commentDto)
        {
            return new Models.Comment
            {
                Title = commentDto.Title,
                Content = commentDto.Content,
                CreatedOn = DateTime.Now,
                StockId = commentDto.StockId
            };
        }

         static Models.Comment ToCreateCommentDTO(CreateCommentDTO commentDto)
        {
            return new Models.Comment
            {
                Title = commentDto.Title,
                Content = commentDto.Content,
                CreatedOn = DateTime.Now,
                StockId = commentDto.StockId
            };
        }
    }
}
