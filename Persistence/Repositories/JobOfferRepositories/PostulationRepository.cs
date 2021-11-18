using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.JobOfferSystem;
using jobagapi.Domain.Repositories;
using jobagapi.Domain.Repositories.PostulantRepositories;
using jobagapi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace jobagapi.Persistence.Repositories.JobOfferRepositories
{
    public class PostulationRepository : BaseRepository, IPostulationRepository 
    {
        public PostulationRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Postulation>> ListAsync()
        {
            return await _context.Postulations.ToListAsync();
        }

        public async Task AddAsync(Postulation postulation)
        {
            await _context.Postulations.AddAsync(postulation);
        }

        public async Task<Postulation> FindByIdAsync(int id)
        {
            return await _context.Postulations.FindAsync(id);
        }
        
        public void update(Postulation postulation)
        {
            _context.Postulations.Update(postulation);
        }

        public void Delete(Postulation postulation)
        {
            _context.Postulations.Remove(postulation);
        }
    }
}