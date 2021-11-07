using System;

namespace jobagapi.Domain.Models
{
    public class Interview
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public double Duration { get; set; }
        public DateTime StartDate { get; set; }
        public bool Pending { get; set; }
    }
}