using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jobagapi.Domain.Models.PostulantSystem
{
    public class Postulant: User
    {
        public string CivilStatus { get; set; }
        
        public int ProfileId { get; set; }
        
        public ProfessionalProfile Profile { get; set; }
    }
}
