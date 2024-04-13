namespace StockWebApp.Comment
{
    public class CommentDto
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public int? StockId { get; set; }
    }
}