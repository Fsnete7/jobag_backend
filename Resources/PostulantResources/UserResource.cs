using System;

namespace jobagapi.Resources.PostulantResources
{
    public class UserResource
    {
        public int Id { get; set; }
        
        public string Firstname { get; set; }
 
        public string Lastname { get; set; }
 
        public string Email { get; set; }
 
        public string Password { get; set; }
        
        public long PhoneNumber { get; set; }
        
        public DateTime Birthday { get; set; }
    }
}