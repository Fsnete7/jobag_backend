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
        Task<Language> FindById(int id);
        void Update(Language language);
        Task<IEnumerable<Language>> ListAsync();
    }
}