using jobagapi.Domain.Models.SubscriptionSystem;

namespace jobagapi.Domain.Services.Communication.SubscriptionResponse
{
    public class SavePaymentResponse: BaseResponse<Payment>
    {
        public SavePaymentResponse(Payment resource) : base(resource) { }

        public SavePaymentResponse(string message = null) : base(message) { }
    }
}