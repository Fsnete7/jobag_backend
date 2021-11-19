using System.ComponentModel.DataAnnotations;

namespace jobagapi.Resources.JobOfferResources
{
    public class SaveContractResource
    {
 
        [Required]
        [MaxLength(250)]
        public string Description { get; set; }
        
        [Required]
        public bool Confirmation { get; set; }
    }
}