using System;

namespace jobagapi.Domain.Models.SuscriptionSystem
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
