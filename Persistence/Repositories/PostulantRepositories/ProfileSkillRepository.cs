using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jobagapi.Domain.Models.PostulantSystem;
using jobagapi.Domain.Repositories.PostulantRepositories;
using jobagapi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace jobagapi.Persistence.Repositories.PostulantPersistence
{
    public class ProfileSkillRepository: BaseRepository, IProfileSkillRepository
    {
        public ProfileSkillRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ProfileSkill>> ListAsync()
        {
            return await _context.ProfileSkills
                .Include(pt => pt.Skill)
                .Include(pt => pt.ProfessionalProfile)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProfileSkill>> ListByProfileIdAsync(int profileId)
        {
            return await _context.ProfileSkills
                .Where(pt => pt.ProfileId == profileId)
                .Include(pt => pt.Skill)
                .Include(pt => pt.ProfessionalProfile)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProfileSkill>> ListBySkillIdAsync(int skillId)
        {
            return await _context.ProfileSkills
                .Where(pt => pt.SkillId == skillId)
                .Include(pt => pt.Skill)
                .Include(pt => pt.ProfessionalProfile)
                .ToListAsync();
        }

        public async Task<ProfileSkill> FindByProfileIdAndSkillId(int profileId, int skillId)
        {
            return await _context.ProfileSkills.FindAsync(profileId, skillId);
        }

        public async Task AddAsync(ProfileSkill profileSkill)
        {
            await _context.ProfileSkills.AddAsync(profileSkill);
        }

        public void Remove(ProfileSkill profileSkill)
        {
            _context.ProfileSkills.Remove(profileSkill);
        }

        public async Task AssignProfileSkill(int profileId, int skillId)
        {
            ProfileSkill profileSkill = await FindByProfileIdAndSkillId(profileId, skillId);
            if (profileSkill == null)
            {
                profileSkill = new ProfileSkill { ProfileId = profileId, SkillId = skillId };
                await AddAsync(profileSkill);
            }
        }

        public async Task UnassignProfileSkill(int profileId, int skillId)
        {
            ProfileSkill profileSkill = await FindByProfileIdAndSkillId(profileId, skillId);
            if (profileSkill != null)
                Remove(profileSkill);
        }
    }
}