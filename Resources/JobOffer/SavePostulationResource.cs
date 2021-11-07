using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using jobagapi.Domain.Models;

namespace jobagapi.Resources
{
    public class SavePostulationResource
    {
        //[Required]
        //[MaxLength(250)]
        //public List<ProfessionalProfile> PostulantProfiles { get; set; }
        
        [Required]
        [MaxLength(30)]
        public JobOffer JobOffer { get; set; }
    }
}