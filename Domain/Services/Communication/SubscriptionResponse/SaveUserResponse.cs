using jobagapi.Domain.Models.SubscriptionSystem;

namespace jobagapi.Domain.Services.Communication.SubscriptionResponse
{
    public class SaveUserResponse : BaseResponse<User>
    {
        public SaveUserResponse(User resource) : base(resource) { }
        public SaveUserResponse(string message = null) : base(message) { }
    }
}