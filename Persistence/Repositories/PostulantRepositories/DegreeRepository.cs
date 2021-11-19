using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.PostulantSystem;
using jobagapi.Domain.Repositories.PostulantRepositories;
using jobagapi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace jobagapi.Persistence.Repositories.PostulantPersistence
{
    public class DegreeRepository: BaseRepository, IDegreeRepository
    {
        public DegreeRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(Degree degree)
        {
            await _context.Degrees.AddAsync(degree);
        }

        public void Remove(Degree degree)
        {
            _context.Degrees.Remove(degree);
        }

        public void Update(Degree degree)
        {
            _context.Degrees.Update(degree);

        }

        public async Task<Degree> FindById(int id)
        {
            return await _context.Degrees.FindAsync(id);
        }

        public async Task<IEnumerable<Degree>> ListAsync()
        {
            return await _context.Degrees.ToListAsync();
        }
    }
}