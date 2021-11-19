using System.ComponentModel.DataAnnotations;

namespace jobagapi.Resources.SubscriptionResources
{
    public class SaveUserResource
    {
        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(30)]
        public string Email { get; set; }
        [Required]
        public long PhoneNumber { get; set; }
        [Required]
        [MaxLength(30)]
        public string PassWord { get; set; }
    }
}