namespace StockWebApp.Helper
{
    public class QueryObject
    {
        public string? Symbol { get; set; }
        public string? CompanyName { get; set; }

        public string? SorrtBy { get; set; }
        public bool? IsDecending { get; set; } = false;

        //Pagination
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
