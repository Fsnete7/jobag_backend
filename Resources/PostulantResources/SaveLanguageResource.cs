using System.ComponentModel.DataAnnotations;

namespace jobagapi.Resources.PostulantResources
{
    public class SaveLanguageResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        
        
        [Required]
        [MaxLength(30)]
        public string Level { get; set; }
    }
}