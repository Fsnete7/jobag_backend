using System.Collections.Generic;

namespace jobagapi.Domain.Models
{
    public class Postulation
    {
        public int Id { get; set; }
        //public List<ProfessionalProfile> PostulantProfiles { get; set; }
        public JobOffer JobOffer { get; set; }
    }
}