using System.ComponentModel.DataAnnotations;

namespace jobagapi.Resources.JobOfferResources
{
    public class SaveContractResource
    {
        [Required]
        [MaxLength(250)]
        public string Description { get; set; }
        
        [Required]
        [MaxLength(30)]
        public bool Confirmation { get; set; }
    }
}