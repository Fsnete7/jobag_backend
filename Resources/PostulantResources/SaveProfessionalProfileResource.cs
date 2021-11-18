using System.ComponentModel.DataAnnotations;

namespace jobagapi.Resources.PostulantResources
{
    public class SaveProfessionalProfileResource
    {
         
        [Required]
        [MaxLength(30)]
        public string Ocupation { get; set; }

        [Required]
        [MaxLength(250)]
        public string VideoUrl { get; set; }
        
        [Required]
        [MaxLength(250)]
        public string Description { get; set; }
        
        [Required]
        public int PostulantId { get; set; }
    }
}