using System.Threading.Tasks;
using jobagapi.Domain.Repositories;
using jobagapi.Persistence.Contexts;

namespace jobagapi.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompletedAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
