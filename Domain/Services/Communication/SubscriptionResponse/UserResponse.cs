using jobagapi.Domain.Models.SubscriptionSystem;

namespace jobagapi.Domain.Services.Communication.SubscriptionResponse
{
    public class UserResponse : BaseResponse<User>
    {
        public UserResponse(User resource) : base(resource) { }
        public UserResponse(string message) : base(message) { }
    }
}