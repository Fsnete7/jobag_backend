using jobagapi.Domain.Models.SuscriptionSystem;

namespace jobagapi.Domain.Services.Communication
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

        public AuthenticateResponse(User user, string token)
        {
            Id = user.Id;
            Email = user.Email;
            Token = token;
        }
    }
}
