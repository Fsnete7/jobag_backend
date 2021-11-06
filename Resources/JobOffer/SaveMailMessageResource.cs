using System.ComponentModel.DataAnnotations;

namespace jobagapi.Resources
{
    public class SaveMailMessageResource
    {
        [Required]
        public string Message { get; set; }
    }
}