using System.ComponentModel.DataAnnotations;

namespace jobagapi.Resources.EmployerResources
{
    public class SaveSectorResource
    {
        [Required]
        [MaxLength(50)]
        public string Name { set; get; }
        
        [Required]
        [MaxLength(250)]
        public string Description { set; get; }
    }
}