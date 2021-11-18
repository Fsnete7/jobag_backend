using System.ComponentModel.DataAnnotations;

namespace jobagapi.Resources.PostulantResources
{
    public class SaveSkillResource
    {
        
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        [MaxLength(30)]
        public string Description { get; set; }
    }
}