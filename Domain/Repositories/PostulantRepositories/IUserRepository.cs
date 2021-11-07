using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.PostulantSystem;

namespace jobagapi.Domain.Repositories.PostulantRepositories
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User> FindById(int id);
        Task<User> Authenticate(string email, string password);
        void Remove(User user);
        Task<IEnumerable<User>> ListAsync();
    }
}