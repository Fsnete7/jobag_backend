using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.SubscriptionSystem;
using jobagapi.Domain.Services.Communication;
using jobagapi.Domain.Services.Communication.SubscriptionResponse;

namespace jobagapi.Domain.Services.SubscriptionServices
{
    public interface IUserService
    {
        //Get
        Task<IEnumerable<User>> ListAsync();
        //Post
        Task<SaveUserResponse> SaveAsync(User user);
        //UpdateOrModify
        Task<SaveUserResponse> UpdateAsync(int id, User user);
        //delete
        Task<UserResponse> DeleteAsync(int id);
    }
}