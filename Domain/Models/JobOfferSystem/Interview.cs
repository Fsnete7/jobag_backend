using System;

namespace jobagapi.Domain.Models.JobOfferSystem
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