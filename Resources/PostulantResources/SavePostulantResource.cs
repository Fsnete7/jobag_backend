using System.ComponentModel.DataAnnotations;
using jobagapi.Resources.SuscriptionResources;

namespace jobagapi.Resources.PostulantResources
{
    public class SavePostulantResource: UserResource
    {
        [Required]
        [MaxLength(30)]
        public string CivilStatus { get; set; }
    }
}