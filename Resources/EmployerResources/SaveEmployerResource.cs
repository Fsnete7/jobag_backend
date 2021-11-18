

using System.ComponentModel.DataAnnotations;
using jobagapi.Resources.SubscriptionResources;

namespace jobagapi.Resources.EmployerResources
{
    public class SaveEmployerResource : SaveUserResource
    {
        [Required]
        public string Position { get; set; }
        
        
    }
}