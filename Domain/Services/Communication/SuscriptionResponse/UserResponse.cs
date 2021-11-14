using jobagapi.Domain.Models.SuscriptionSystem;

namespace jobagapi.Domain.Services.Communication.SuscriptionResponse
{
    public class UserResponse : BaseResponse<User>
    {
        public UserResponse(string message) : base(message) { }

        public UserResponse(User user) : base(user) { }
    }
}