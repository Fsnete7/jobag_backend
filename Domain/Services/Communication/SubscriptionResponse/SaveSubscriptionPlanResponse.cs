using jobagapi.Domain.Models.SubscriptionSystem;

namespace jobagapi.Domain.Services.Communication.SubscriptionResponse
{
    public class SaveSubscriptionPlanResponse : BaseResponse<SubscriptionPlan>
    {
        public SaveSubscriptionPlanResponse(SubscriptionPlan resource) : base(resource) { }
        public SaveSubscriptionPlanResponse(string message = null) : base(message) { }
    }
}