using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jobagapi.Domain.Repositories;
using jobagapi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace jobagapi.Persistence.Repositories.JobOffer.JobOffer
{
    public class InterviewRepository : BaseRepository, IInterviewRepository
    {
        public InterviewRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Domain.Models.Interview>> ListAsync()
        {
            return await _context.Interviews.ToListAsync();
        }

        public async Task AddAsync(Domain.Models.Interview interview)
        {
            await _context.Interviews.AddAsync(interview);
        }

        public async Task<Domain.Models.Interview> FindByIdAsync(int id)
        {
            return await _context.Interviews.FindAsync(id);
        }
        
        public void update(Domain.Models.Interview interview)
        {
            _context.Interviews.Update(interview);
        }

        public void Delete(Domain.Models.Interview interview)
        {
            _context.Interviews.Remove(interview);
        }
    }
}