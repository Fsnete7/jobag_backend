namespace jobagapi.Resources.SubscriptionResources
{
    public class SavePaymentResource
    {
        public int PaymentId { get; set; }
        public int CarNumber { get; set; }
        public float AmountTotal { get; set; }
        public string Details { get; set; }
    }
}