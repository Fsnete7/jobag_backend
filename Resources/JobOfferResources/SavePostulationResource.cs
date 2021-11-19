using System.ComponentModel.DataAnnotations;

namespace jobagapi.Resources.JobOfferResources
{
    public class SavePostulationResource
    {
        [Required]
        public int PostulationId { get; set; }
        [Required]
        public int PostulantId { get; set; }
        [Required]
        public int JobOfferId { get; set; }
        [Required]
        [MaxLength(250)]
        public string UrlVideo { get; set; }
        [Required]
        public bool Accepted { get; set; }

    }
}