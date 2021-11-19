using jobagapi.Domain.Models.SubscriptionSystem;

namespace jobagapi.Domain.Services.Communication.SubscriptionResponse
{
    public class PaymentResponse: BaseResponse<Payment>
    {
        public PaymentResponse(Payment resource) : base(resource) { }
        public PaymentResponse(string message) : base(message) { }
    }
}