using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.PostulantSystem;

namespace jobagapi.Domain.Repositories.PostulantRepositories
{
    public interface IProfileSkillRepository
    {
        Task<IEnumerable<ProfileSkill>> ListAsync();
        Task<IEnumerable<ProfileSkill>> ListByProfileIdAsync(int profileId);
        Task<IEnumerable<ProfileSkill>> ListBySkillIdAsync(int skillId);
        Task<ProfileSkill> FindByProfileIdAndSkillId(int profileId, int skillId);
        Task AddAsync(ProfileSkill profileSkill);
        void Remove(ProfileSkill profileSkill);
        Task AssignProfileSkill(int profileId, int skillId);
        Task UnassignProfileSkill(int profileId, int skillId);
    }
}