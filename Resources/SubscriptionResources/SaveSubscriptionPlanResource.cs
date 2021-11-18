using System.ComponentModel.DataAnnotations;

namespace jobagapi.Resources.SubscriptionResources
{
    public class SaveSubscriptionPlanResource
    {
        [Required]
        [MaxLength(120)]
        public string Description { get; set; }
        [Required]
        public int LimitVideoCreation { get; set; }
        [Required]
        public bool PreDesignTemplates { get; set; }
        [Required]
        public int Duration { get; set; }
        [Required]
        public int LimitModification { get; set; }
        [Required]
        public bool Assistance { get; set; }
    }
}