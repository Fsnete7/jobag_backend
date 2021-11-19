using System.ComponentModel.DataAnnotations;

namespace jobagapi.Resources.JobOfferResources
{
    public class SaveMailMessageResource
    {
        [Required]
        public string Message { get; set; }
    }
}