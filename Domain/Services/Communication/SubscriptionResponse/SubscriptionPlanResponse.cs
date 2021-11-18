using jobagapi.Domain.Models.SubscriptionSystem;

namespace jobagapi.Domain.Services.Communication.SubscriptionResponse
{
    public class SubscriptionPlanResponse : BaseResponse<SubscriptionPlan>
    {
        public SubscriptionPlanResponse(SubscriptionPlan resource) : base(resource) { }
        public SubscriptionPlanResponse(string message) : base(message) { }
    }
}