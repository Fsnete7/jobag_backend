using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.SuscriptionSystem;
using jobagapi.Domain.Services.Communication;
using jobagapi.Domain.Services.Communication.SuscriptionResponse;

namespace jobagapi.Domain.Services.SuscriptionServices
{
    public interface IUserService
    {
        Task<UserResponse> GetByIdAsync(int id);
        Task<UserResponse> SaveAsync(User user);
        Task<IEnumerable<User>> ListAsync();
        Task<UserResponse> DeleteAsync(int id);
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest request);
    }
}