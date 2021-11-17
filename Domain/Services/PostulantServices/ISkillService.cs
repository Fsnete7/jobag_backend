using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.PostulantSystem;
using jobagapi.Domain.Services.Communication.PostulantResponse;

namespace jobagapi.Domain.Services.PostulantServices
{
    public interface ISkillService
    {
        Task<SkillResponse> GetByIdAsync(int id);
        Task<SkillResponse> SaveAsync(Skill skill);
        Task<IEnumerable<Skill>> ListAsync();
        Task<SkillResponse> DeleteAsync(int id);
    }
}