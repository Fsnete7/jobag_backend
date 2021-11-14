using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Repositories.JobOfferRepositories;
using jobagapi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace jobagapi.Persistence.Repositories.JobOfferPersistence
{
    public class JobOfferRepository : BaseRepository, IJobOfferRepository
    {
        public JobOfferRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Domain.Models.JobOfferSystem.JobOffer>> ListAsync()
        {
            return await _context.JobOffers.ToListAsync();
        }

        public async Task AddAsync(Domain.Models.JobOfferSystem.JobOffer jobOffer)
        {
            await _context.JobOffers.AddAsync(jobOffer);
        }

        public async Task<Domain.Models.JobOfferSystem.JobOffer> FindByIdAsync(int id)
        {
            return await _context.JobOffers.FindAsync(id);
        }
        
        public void update(Domain.Models.JobOfferSystem.JobOffer jobOffer)
        {
            _context.JobOffers.Update(jobOffer);
        }

        public void Delete(Domain.Models.JobOfferSystem.JobOffer jobOffer)
        {
            _context.JobOffers.Remove(jobOffer);
        }
    }
}