using System.Threading.Tasks;
using jobagapi.Domain.Models.PostulantSystem;

namespace jobagapi.Domain.Repositories.PostulantRepositories
{
    public interface ISkillRepository
    {
        Task AddAsync(Skill skill);
        void Remove(Skill skill);
        Task AssignSkill(int profileId, int skillId);
        void UnassignSkill(int profileId, int skillId);
    }
}