using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.EmployerSystem;
using jobagapi.Domain.Repositories.EmployerRepositories;
using jobagapi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace jobagapi.Persistence.Repositories.EmployerRepositories
{
    public class CompanyProfileRepository : BaseRepository, ICompanyProfileRepository
    {
        public CompanyProfileRepository(AppDbContext context) : base(context)
        {
        }  
        
        public async Task<IEnumerable<CompanyProfile>> ListAsync()
        {
            return await _context.CompanyProfiles.ToListAsync();
        }

        public async Task AddAsync(CompanyProfile companyProfile)
        {
            await _context.CompanyProfiles.AddAsync(companyProfile);
        }

        public async Task<CompanyProfile> FindByIdAsync(int id)
        {
            return await _context.CompanyProfiles.FindAsync(id);
        }
        
        public void Update(CompanyProfile companyProfile)
        {
            _context.CompanyProfiles.Update(companyProfile);
        }

        public void Delete(CompanyProfile companyProfile)
        {
            _context.CompanyProfiles.Remove(companyProfile);
        }
    }
}