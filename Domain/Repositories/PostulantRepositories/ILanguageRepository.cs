using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.PostulantSystem;
using jobagapi.Domain.Services.Communication.PostulantResponse;

namespace jobagapi.Domain.Repositories.PostulantRepositories
{
    public interface ILanguageRepository
    {
        Task AddAsync(Language language);
        void Remove(Language language);
        Task AssignLanguage(int profileId, int languageId);
        void UnassignLanguage(int profileId, int languageId);

        Task<Language> FindById(int id);
        Task<IEnumerable<Language>> ListAsync();
    }
}