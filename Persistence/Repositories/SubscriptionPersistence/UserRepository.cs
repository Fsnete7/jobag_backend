using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.SubscriptionSystem;
using jobagapi.Domain.Repositories.SubscriptionRepositories;
using jobagapi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace jobagapi.Persistence.Repositories.SubscriptionPersistence
{
    public class UserRepository: BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }
        //get
        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _context.Users.ToListAsync();
        }
        //post
        public async Task AddAsync(User user)
        {
            await _context.AddAsync(user);
        }
        //update
        public async Task<User> FindByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }
        public void Update(User user)
        {
            _context.Update(user);
        }
        //delete
        public void Remove(User user)
        {
            _context.Remove(user);
        }
    }
}