using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.PostulantSystem;
using jobagapi.Domain.Services.Communication.PostulantResponse;

namespace jobagapi.Domain.Repositories.PostulantRepositories
{
    public interface ISkillRepository
    {
        Task AddAsync(Skill skill);
        void Remove(Skill skill);
        Task AssignSkill(int profileId, int skillId);
        void UnassignSkill(int profileId, int skillId);
        Task<Skill> FindById(int id);
        Task<IEnumerable<Skill>> ListAsync();
    }
}