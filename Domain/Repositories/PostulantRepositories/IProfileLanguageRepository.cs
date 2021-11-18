using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.PostulantSystem;

namespace jobagapi.Domain.Repositories.PostulantRepositories
{
    public interface IProfileLanguageRepository
    {
        Task<IEnumerable<ProfileLanguage>> ListAsync();
        Task<IEnumerable<ProfileLanguage>> ListByProfileIdAsync(int profileId);
        Task<IEnumerable<ProfileLanguage>> ListByLanguageIdAsync(int languageId);
        Task<ProfileLanguage> FindByProfileIdAndSkillId(int profileId, int languageId);
        Task AddAsync(ProfileLanguage profileLanguage);
        void Remove(ProfileLanguage profileLanguage);
        Task AssignProfileLanguage(int profileId, int languageId);
        Task UnassignProfileLanguage(int profileId, int languageId);
    }
}