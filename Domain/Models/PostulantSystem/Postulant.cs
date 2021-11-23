using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jobagapi.Domain.Models.JobOfferSystem;
using jobagapi.Domain.Models.SubscriptionSystem;
 
namespace jobagapi.Domain.Models.PostulantSystem
{
    public class Postulant : User
    {
        public string CivilStatus { get; set; }
        
        public ProfessionalProfile ProfessionalProfile { get; set; }
        
        public List<Postulation> Postulations { get; set; }
        public List<Interview> Interviews { get; set; }
    }
}
