using System;
using System.ComponentModel.DataAnnotations;

namespace jobagapi.Resources.PostulantSaveResources
{
    public class UserSaveResource
    {
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public long PhoneNumber { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
    }
}