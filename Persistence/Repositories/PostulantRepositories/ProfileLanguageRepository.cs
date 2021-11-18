using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jobagapi.Domain.Models.PostulantSystem;
using jobagapi.Domain.Repositories.PostulantRepositories;
using jobagapi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace jobagapi.Persistence.Repositories.PostulantPersistence
{
    public class ProfileLanguageRepository: BaseRepository, IProfileLanguageRepository
    {
        public ProfileLanguageRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ProfileLanguage>> ListAsync()
        {
            return await _context.ProfileLanguages
                .Include(pt => pt.Language)
                .Include(pt => pt.ProfessionalProfile)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProfileLanguage>> ListByProfileIdAsync(int profileId)
        {
            return await _context.ProfileLanguages
                .Where(pt => pt.ProfileId == profileId)
                .Include(pt => pt.Language)
                .Include(pt => pt.ProfessionalProfile)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProfileLanguage>> ListByLanguageIdAsync(int languageId)
        {
            return await _context.ProfileLanguages
                .Where(pt => pt.LanguageId == languageId)
                .Include(pt => pt.Language)
                .Include(pt => pt.ProfessionalProfile)
                .ToListAsync();
        }

        public async Task<ProfileLanguage> FindByProfileIdAndSkillId(int profileId, int languageId)
        {
            return await _context.ProfileLanguages.FindAsync(profileId, languageId);
        }

        public async Task AddAsync(ProfileLanguage profileLanguage)
        {
            await _context.ProfileLanguages.AddAsync(profileLanguage);
        }

        public void Remove(ProfileLanguage profileLanguage)
        {
            _context.ProfileLanguages.Remove(profileLanguage);        }

        public async Task AssignProfileLanguage(int profileId, int languageId)
        {
            ProfileLanguage profileLanguage = await FindByProfileIdAndSkillId(profileId, languageId);
            if (profileLanguage == null)
            {
                profileLanguage = new ProfileLanguage { ProfileId = profileId, LanguageId = languageId };
                await AddAsync(profileLanguage);
            }
        }

        public async Task UnassignProfileLanguage(int profileId, int languageId)
        {
            ProfileLanguage profileLanguage = await FindByProfileIdAndSkillId(profileId, languageId);
            if (profileLanguage != null)
                Remove(profileLanguage);
        }
    }
}