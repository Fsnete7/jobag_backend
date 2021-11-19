using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.PostulantSystem;
using jobagapi.Domain.Repositories.PostulantRepositories;
using jobagapi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace jobagapi.Persistence.Repositories.PostulantPersistence
{
    public class ProfessionalProfileRepository: BaseRepository, IProfessionalRepository
    {
        public ProfessionalProfileRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddAsync(ProfessionalProfile profile)
        {
            await _context.Profiles.AddAsync(profile);
        }

        public async Task<ProfessionalProfile> FindById(int id)
        {
            return await _context.Profiles.FindAsync(id);
        }

        public void Update(ProfessionalProfile professionalProfile)
        {
            _context.Profiles.Update(professionalProfile);
        }

        public void Remove(ProfessionalProfile profile)
        {
            _context.Profiles.Remove(profile);
        }

        public async Task<IEnumerable<ProfessionalProfile>> ListAsync()
        {
            return await _context.Profiles.ToListAsync();
        }

 
    }
}