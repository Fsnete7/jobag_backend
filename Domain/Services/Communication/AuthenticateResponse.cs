using jobagapi.Domain.Models.SubscriptionSystem;

namespace jobagapi.Domain.Services.Communication
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

        public AuthenticateResponse(User user, string token)
        {
            Id = user.UserId;
            Email = user.Email;
            Token = token;
        }
    }
}
