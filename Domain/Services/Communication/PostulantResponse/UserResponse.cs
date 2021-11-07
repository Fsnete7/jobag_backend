using jobagapi.Domain.Models.PostulantSystem;

namespace jobagapi.Domain.Services.Communication.PostulantResponse
{
    public class UserResponse : BaseResponse<User>
    {
        public UserResponse(string message) : base(message) { }

        public UserResponse(User user) : base(user) { }
    }
}