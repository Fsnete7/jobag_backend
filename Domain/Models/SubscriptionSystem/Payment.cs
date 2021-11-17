using System.Collections;
using System.Collections.Generic;

namespace jobagapi.Domain.Models.SubscriptionSystem
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int CarNumber { get; set; }
        public float AmountTotal { get; set; }
        public string Details { get; set; }
        
        //RelationShip - SubscriptionPlan
        public IList<SubscriptionPlan> SubscriptionPlans { get; set; } = new List<SubscriptionPlan>();

        //RelationShip - User
        public IList<User> Users { get; set; } = new List<User>();
    }
}