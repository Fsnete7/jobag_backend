using System;
using jobagapi.Domain.Models.JobOfferSystem;

namespace jobagapi.Resources.JobOfferResources
{
    public class InterviewResource
    {
        
        public int Id { get; set; }
        public string Link { get; set; }
        public double Duration { get; set; }
        public DateTime StartDate { get; set; }
        public bool Pending { get; set; }
        
        public int JobOfferId { get; set; }
        public int PostulantId { get; set; }

    }
}