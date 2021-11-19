using jobagapi.Domain.Models.EmployerSystem;

namespace jobagapi.Domain.Models.SubscriptionSystem
{
    public class SubscriptionPlan
    {
        public int SubscriptionPlanId { get; set; }
        public string Description { get; set; }
        public int LimitPostulation { get; set; }
        public int LimitVideoCreation { get; set; }
        public bool PreDesignTemplates { get; set; }
        public int Duration { get; set; }
        public int LimitModification { get; set; }
        public bool Assistance { get; set; }
        
        //RelationShip - Employer
        public int EmployerId { get; set; }
        public Employer Employer { get; set; }
        
        //RelationShip - Payment
        public int PaymentId { get; set; }
        public Payment Payment { get; set; }
    }
}