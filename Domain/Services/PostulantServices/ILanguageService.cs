using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.PostulantSystem;
using jobagapi.Domain.Services.Communication.PostulantResponse;

namespace jobagapi.Domain.Services.PostulantServices
{
    public interface ILanguageService
    {
        Task<LanguageResponse> GetByIdAsync(int id);
        Task<IEnumerable<Language>> ListByProfileIdAsync(int profileId);
        Task<LanguageResponse> SaveAsync(Language language);
        Task<IEnumerable<Language>> ListAsync();
        Task<LanguageResponse> DeleteAsync(int id);
        
        Task<LanguageResponse> UpdateAsync(int id, Language language);
    }
}