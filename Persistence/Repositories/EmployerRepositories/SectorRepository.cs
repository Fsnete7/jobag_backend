using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.EmployerSystem;
using jobagapi.Domain.Repositories.EmployerRepositories;
using jobagapi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace jobagapi.Persistence.Repositories.EmployerRepositories
{
    public class SectorRepository : BaseRepository, ISectorRepository
    {
        public SectorRepository(AppDbContext context) : base(context)
        {
        }  
        
        public async Task<IEnumerable<Sector>> ListAsync()
        {
            return await _context.Sectors.ToListAsync();
        }

        public async Task AddAsync(Sector sector)
        {
            await _context.Sectors.AddAsync(sector);
        }

        public async Task<Sector> FindByIdAsync(int id)
        {
            return await _context.Sectors.FindAsync(id);
        }
        
        public void Update(Sector sector)
        {
            _context.Sectors.Update(sector);
        }

        public void Delete(Sector sector)
        {
            _context.Sectors.Remove(sector);
        }
        
    }
}