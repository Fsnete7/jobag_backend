

using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.SubscriptionSystem;

namespace jobagapi.Domain.Repositories.SubscriptionRepositories
{
    public interface IUserRepository
    {
        //Get
        Task<IEnumerable<User>> ListAsync();
        //post
        Task AddAsync(User user);
        //Update
        Task<User> FindByIdAsync(int id);
        void Update(User user);
        //delete
        void Remove(User user);
    }
}