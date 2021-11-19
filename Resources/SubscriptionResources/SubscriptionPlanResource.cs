namespace jobagapi.Resources.SubscriptionResources
{
    public class SubscriptionPlanResource
    {
        public int SubscriptionPlanId { get; set; }
        public string Description { get; set; }
        public int LimitVideoCreation { get; set; }
        public bool PreDesignTemplates { get; set; }
        public int Duration { get; set; }
        public int LimitModification { get; set; }
        public bool Assistance { get; set; }
    }
}