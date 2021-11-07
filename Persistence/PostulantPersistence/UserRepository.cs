using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.PostulantSystem;
using jobagapi.Domain.Persistence.Contexts;
using jobagapi.Domain.Repositories.PostulantRepositories;
using Microsoft.EntityFrameworkCore;

namespace jobagapi.Persistence.PostulantPersistence
{
    public class UserRepository: BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context) { }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<User> FindById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public void Remove(User user)
        {
            _context.Users.Remove(user);
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}