﻿namespace StockWebApp.Helper
{
    public class EmailSettings
    {
        public string EmailHost { get; set; } = string.Empty;
        public int EmailPort { get; set; }
        public string? EmailUserName { get; set; } 
        public string EmailPassword { get; set; } = string.Empty;
    }
}
