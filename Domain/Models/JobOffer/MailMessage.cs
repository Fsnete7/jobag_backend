﻿namespace jobagapi.Domain.Models
{
    public class MailMessage
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string DocumentLink { get; set; }
    }
}