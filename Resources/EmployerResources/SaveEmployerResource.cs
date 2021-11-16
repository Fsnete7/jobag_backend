

using System.ComponentModel.DataAnnotations;

namespace jobagapi.Resources.EmployerResources
{
    public class SaveEmployerResource
    {
        [Required]
        public int Position { get; set; }
    }
}