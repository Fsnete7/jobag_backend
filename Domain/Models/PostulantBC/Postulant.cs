using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jobagapi.Domain.Models.PostulantBC
{
    public class Postulant: User
    {   

        public int UserId { get; set; }

        public new int Id { get; set; }
        public string Dni { get; set; }

        public DateTime Birthday { get; set; }

        public string CivilStatus { get; set; }
    }
}
