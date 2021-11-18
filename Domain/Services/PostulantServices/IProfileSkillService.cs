using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.PostulantSystem;
using jobagapi.Domain.Services.Communication.PostulantResponse;

namespace jobagapi.Domain.Services.PostulantServices
{
    public interface IProfileSkillService
    {
        Task<IEnumerable<ProfileSkill>> ListAsync();
        Task<IEnumerable<ProfileSkill>> ListByProfileIdAsync(int profileId);
        Task<IEnumerable<ProfileSkill>> ListBySkillIdAsync(int skillId);
        Task<ProfileSkillResponse> AssignProfileSkillAsync(int profileId, int skillId);
        Task<ProfileSkillResponse> UnassignProfileSkillAsync(int profileId, int skillId);
    }
}