using System.Collections;
using System.Collections.Generic;
using jobagapi.Domain.Models.PostulantSystem;

namespace jobagapi.Domain.Models.JobOfferSystem
{
    public class Postulation
    {
        public int PostulationId { get; set; }
        
        public Postulant Postulant { get; set; }
        
        public int PostulantId { get; set; }
        public JobOffer JobOffer { get; set; }
        
        public int JobOfferId { get; set; }
        
        public string UrlVideo { get; set; }
        
        public bool Accepted { get; set; }
        
        
    }
}