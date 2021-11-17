using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.EmployerSystem;
using jobagapi.Domain.Repositories.EmployerRepositories;
using jobagapi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace jobagapi.Persistence.Repositories.EmployerRepositories
{
    public class EmployerRepository : BaseRepository, IEmployerRepository
    {
        public EmployerRepository(AppDbContext context) : base(context)
        {
        }  
        
        public async Task<IEnumerable<Employer>> ListAsync()
        {
            return await _context.Employers.ToListAsync();
        }

        public async Task AddAsync(Employer employer)
        {
            await _context.Employers.AddAsync(employer);
        }

        public async Task<Employer> FindByIdAsync(int id)
        {
            return await _context.Employers.FindAsync(id);
        }
        
        public void Update(Employer employer)
        {
            _context.Employers.Update(employer);
        }

        public void Delete(Employer employer)
        {
            _context.Employers.Remove(employer);
        }
    }
}