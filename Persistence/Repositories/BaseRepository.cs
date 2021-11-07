using jobagapi.Domain.Models;
using jobagapi.Persistence.Contexts;

namespace jobagapi.Persistence.Repositories.JobOffer
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}