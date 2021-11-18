using System.ComponentModel.DataAnnotations;
using jobagapi.Resources.SubscriptionResources;
<<<<<<< HEAD
 
=======
>>>>>>> main

namespace jobagapi.Resources.PostulantResources
{
    public class SavePostulantResource: UserResource
    {
        [Required]
        [MaxLength(30)]
        public string CivilStatus { get; set; }
    }
}