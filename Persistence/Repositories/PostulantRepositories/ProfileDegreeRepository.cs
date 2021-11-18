using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jobagapi.Domain.Models.PostulantSystem;
using jobagapi.Domain.Repositories.PostulantRepositories;
using jobagapi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace jobagapi.Persistence.Repositories.PostulantPersistence
{
    public class ProfileDegreeRepository: BaseRepository, IProfileDegreeRepository
    {
        public ProfileDegreeRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ProfileDegree>> ListAsync()
        {
            return await _context.ProfileDegrees
                .Include(pt => pt.Degree)
                .Include(pt => pt.ProfessionalProfile)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProfileDegree>> ListByProfileIdAsync(int profileId)
        {
            return await _context.ProfileDegrees
                .Where(pt => pt.ProfileId == profileId)
                .Include(pt => pt.Degree)
                .Include(pt => pt.ProfessionalProfile)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProfileDegree>> ListByDegreeIdAsync(int degreeId)
        {
            return await _context.ProfileDegrees
                .Where(pt => pt.DegreeId == degreeId)
                .Include(pt => pt.Degree)
                .Include(pt => pt.ProfessionalProfile)
                .ToListAsync();
        }

        public async Task<ProfileDegree> FindByProfileIdAndDegreeId(int profileId, int degreeId)
        {
            return await _context.ProfileDegrees.FindAsync(profileId, degreeId);
        }

        public async Task AddAsync(ProfileDegree profileDegree)
        {
            await _context.ProfileDegrees.AddAsync(profileDegree);
        }

        public void Remove(ProfileDegree profileDegree)
        {
            _context.ProfileDegrees.Remove(profileDegree);
        }

        public async Task AssignProfileDegree(int profileId, int degreeId)
        {
            ProfileDegree profileDegree = await FindByProfileIdAndDegreeId(profileId, degreeId);
            if (profileDegree == null)
            {
                profileDegree = new ProfileDegree { ProfileId = profileId, DegreeId = degreeId };
                await AddAsync(profileDegree);
            }
        }

        public async Task UnassignProfileDegree(int profileId, int degreeId)
        {
            ProfileDegree profileDegree = await FindByProfileIdAndDegreeId(profileId, degreeId);
            if (profileDegree != null)
                Remove(profileDegree);
        }
    }
}