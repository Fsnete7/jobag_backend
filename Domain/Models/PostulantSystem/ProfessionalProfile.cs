using System.Collections.Generic;
using jobagapi.Services.PostulantServicesImpl;

namespace jobagapi.Domain.Models.PostulantSystem
{
    public class ProfessionalProfile{

        public int Id { get; set; }
        public string Ocupation { get; set; }
        public string Description { get; set; }

        public string VideoUrl { get; set; }
        
        public Postulant Postulant { get; set;}
        
        public int PostulantId { get; set; }
        
        public List<ProfileDegree> ProfileDegrees { get; set; }
        public List<ProfileSkill> ProfileSkills { get; set; }  
        public List<ProfileLanguage> ProfileLanguages { get; set; }  
    }
}