using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jobagapi.Domain.Models.PostulantSystem
{
    public class User
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        
        public string Email { get; set; }

        public long PhoneNumber { get; set; }
        public string Password { get; set; }
        
        public string Dni { get; set; }

        public DateTime Birthday { get; set; }
    }
}
