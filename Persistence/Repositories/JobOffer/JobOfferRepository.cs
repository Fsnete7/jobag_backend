using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jobagapi.Domain.Repositories;
using jobagapi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace jobagapi.Persistence.Repositories.JobOffer.JobOffer
{
    public class JobOfferRepository : BaseRepository, IJobOfferRepository
    {
        public JobOfferRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Domain.Models.JobOffer>> ListAsync()
        {
            return await _context.JobOffers.ToListAsync();
        }

        public async Task AddAsync(Domain.Models.JobOffer jobOffer)
        {
            await _context.JobOffers.AddAsync(jobOffer);
        }

        public async Task<Domain.Models.JobOffer> FindByIdAsync(int id)
        {
            return await _context.JobOffers.FindAsync(id);
        }
        
        public void update(Domain.Models.JobOffer jobOffer)
        {
            _context.JobOffers.Update(jobOffer);
        }

        public void Delete(Domain.Models.JobOffer jobOffer)
        {
            _context.JobOffers.Remove(jobOffer);
        }
    }
}