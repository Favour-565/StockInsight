namespace StockWebApp.Comment
{
    public class CreateCommentDTO
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public int? StockId { get; set; }
    }
}

