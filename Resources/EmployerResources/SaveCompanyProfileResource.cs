using System.ComponentModel.DataAnnotations;

namespace jobagapi.Resources.EmployerResources
{
    public class SaveCompanyProfileResource
    {
        [Required]
        [MaxLength(250)]
        public string Direction { get; set; }
        
        [Required]
        [MaxLength(30)]
        public string District { get; set; }
        
        [Required]
        [MaxLength(30)]
        public string City { get; set; }
        
        [Required]
        [MaxLength(30)]
        public string Country { get; set; }
        
        [Required]
        public int EmployerId { get; set; }
        
    }
}