namespace jobagapi.Domain.Models.SubscriptionSystem
{
    public class PlansEmployers
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int LimitVideoConference { get; set; }
        public int LimitModification { get; set; }
        public bool Assistance { get; set; }
        public int Duration { get; set; }
    }
}