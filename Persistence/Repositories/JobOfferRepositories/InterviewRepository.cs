using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jobagapi.Domain.Models.JobOfferSystem;
using jobagapi.Domain.Repositories;
using jobagapi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace jobagapi.Persistence.Repositories.JobOfferRepositories
{
    public class InterviewRepository : BaseRepository, IInterviewRepository
    {
        public InterviewRepository(AppDbContext context) : base(context)
        {
        }
        //get
        public async Task<IEnumerable<Interview>> ListAsync()
        {
            return await _context.Interviews.ToListAsync();
        }
        //post
        public async Task AddAsync(Interview interview)
        {
            await _context.AddAsync(interview);
        }
        //update
        public async Task<Interview> FindByIdAsync(int id)
        {
            return await _context.Interviews.FindAsync(id);
        }

        public void Update(Interview interview)
        {
            _context.Update(interview);
        }
        // delete
        public void Remove(Interview interview)
        {
            _context.Remove(interview);
        }

        public async Task<IEnumerable<Interview>> ListByJobOfferIdAsync(int jobOfferId)
        {
            return await _context.Interviews
                .Where(pt => pt.JobOfferId == jobOfferId)
                .Include(pt => pt.Postulant)
                .Include(pt => pt.JobOffer)
                .ToListAsync();
        }

        public async Task<IEnumerable<Interview>> ListByPostulantIdAsync(int postulantId)
        {
            return await _context.Interviews
                .Where(pt => pt.PostulantId == postulantId)
                .Include(pt => pt.JobOffer)
                .Include(pt => pt.Postulant)
                .ToListAsync();
        }

        public async Task<Interview> FindByJobOfferIdAndPostulantId(int jobOfferId, int postulantId)
        {
            return await _context.Interviews.FindAsync(jobOfferId, postulantId);
        }
        
       
    }
}