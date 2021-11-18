using System.ComponentModel.DataAnnotations;

namespace jobagapi.Resources.SubscriptionResources
{
    public class SavePaymentResource
    {
        [Required]
        public int CarNumber { get; set; }
        [Required]
        public float AmountTotal { get; set; }
        [Required]
        [MaxLength(120)]
        public string Details { get; set; }
    }
}