using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using jobagapi.Domain.Models.JobOfferSystem;
using jobagapi.Domain.Models.PostulantSystem;

namespace jobagapi.Resources.JobOfferResources
{
    public class PostulationResource
    {
        public int PostulationId { get; set; }
        public int PostulantId { get; set; }
        
        public int JobOfferId { get; set; }
        
        public string UrlVideo { get; set; }
        
        public bool Accepted { get; set; }

    }
}
//V