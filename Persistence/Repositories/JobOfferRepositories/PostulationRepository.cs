using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jobagapi.Domain.Models.JobOfferSystem;
using jobagapi.Domain.Repositories.JobOfferRepositories;
using jobagapi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace jobagapi.Persistence.Repositories.JobOfferPersistence
{
    public class PostulationRepository : BaseRepository, IPostulationRepository
    {
        public PostulationRepository(AppDbContext context) : base(context)
        {
        }
        //get
        public async Task<IEnumerable<Postulation>> ListAsync()
        {
            return await _context.Postulations.ToListAsync();
        }
        //post
        public async Task AddAsync(Postulation postulation)
        {
            await _context.AddAsync(postulation);
        }
        //update
        public async Task<Postulation> FindByIdAsync(int id)
        {
            return await _context.Postulations.FindAsync(id);
        }
        public void Update(Postulation postulation)
        {
            _context.Update(postulation);
        }
        //delete
        public void Remove(Postulation postulation)
        {
            _context.Remove(postulation);
        }

        public async Task<IEnumerable<Postulation>> ListByJobOfferIdAsync(int jobOfferId)
        {
            return await _context.Postulations
                .Where(pt => pt.JobOfferId == jobOfferId)
                .Include(pt => pt.Postulant)
                .Include(pt => pt.JobOffer)
                .ToListAsync();
        }

        public async Task<IEnumerable<Postulation>> ListByPostulantIdAsync(int postulantId)
        {
            return await _context.Postulations
                .Where(pt => pt.PostulantId == postulantId)
                .Include(pt => pt.JobOffer)
                .Include(pt => pt.Postulant)
                .ToListAsync();
        }

        public async Task<Postulation> FindByJobOfferIdAndPostulantId(int jobOfferId, int postulantId)
        {
            return await _context.Postulations.FindAsync(jobOfferId, postulantId);
        }
    }
}