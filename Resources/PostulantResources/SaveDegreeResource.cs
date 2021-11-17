using System.ComponentModel.DataAnnotations;

namespace jobagapi.Resources.PostulantResources
{
    public class SaveDegreeResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(250)]
        public string Url { get; set; }
    }
}