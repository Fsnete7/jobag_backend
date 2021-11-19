using System;
using jobagapi.Domain.Models.PostulantSystem;

namespace jobagapi.Domain.Models.JobOfferSystem
{
    public class Interview
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public double Duration { get; set; }
        public DateTime StartDate { get; set; }
        public bool Pending { get; set; }
        
        public JobOffer JobOffer { get; set; }
        public int JobOfferId { get; set; }
        
        public int PostulantId { get; set; }
        public Postulant Postulant { get; set; }
    }
}