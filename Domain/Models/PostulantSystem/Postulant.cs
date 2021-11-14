using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jobagapi.Domain.Models.SuscriptionSystem;

namespace jobagapi.Domain.Models.PostulantSystem
{
    public class Postulant: User
    {
        public string CivilStatus { get; set; }
        
      }
}
