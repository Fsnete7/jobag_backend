using System.Threading.Tasks;
using jobagapi.Domain.Persistence.Contexts;
using jobagapi.Domain.Repositories;

namespace jobagapi.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
