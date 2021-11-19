using System.Collections.Generic;
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

        public async Task<IEnumerable<Interview>> ListAsync()
        {
            return await _context.Interviews.ToListAsync();
        }

        public async Task AddAsync(Interview interview)
        {
            await _context.Interviews.AddAsync(interview);
        }

        public async Task<Interview> FindByIdAsync(int id)
        {
            return await _context.Interviews.FindAsync(id);
        }
        
        public void update(Interview interview)
        {
            _context.Interviews.Update(interview);
        }

        public void Delete(Interview interview)
        {
            _context.Interviews.Remove(interview);
        }
    }
}