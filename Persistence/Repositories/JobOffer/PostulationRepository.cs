using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jobagapi.Domain.Repositories;
using jobagapi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace jobagapi.Persistence.Repositories.JobOffer.JobOffer
{
    public class PostulationRepository : BaseRepository, IPostulationRepository
    {
        public PostulationRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Domain.Models.Postulation>> ListAsync()
        {
            return await _context.Postulations.ToListAsync();
        }

        public async Task AddAsync(Domain.Models.Postulation postulation)
        {
            await _context.Postulations.AddAsync(postulation);
        }

        public async Task<Domain.Models.Postulation> FindByIdAsync(int id)
        {
            return await _context.Postulations.FindAsync(id);
        }
        
        public void update(Domain.Models.Postulation postulation)
        {
            _context.Postulations.Update(postulation);
        }

        public void Delete(Domain.Models.Postulation postulation)
        {
            _context.Postulations.Remove(postulation);
        }
    }
}