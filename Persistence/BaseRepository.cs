using jobagapi.Domain.Persistence.Contexts;

namespace jobagapi.Persistence
{
    public class BaseRepository
    {
        protected readonly AppDbContext _context; 
        
        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
