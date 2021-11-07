namespace jobagapi.Domain.Models.SubscriptionSystem
{
    public class PlansPostulant
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int LimitPostulations { get; set; }
        public int LimitVideoCreation { get; set; }
        public int PreDesignTemplates { get; set; }
        public int Duration { get; set; }
    }
}
