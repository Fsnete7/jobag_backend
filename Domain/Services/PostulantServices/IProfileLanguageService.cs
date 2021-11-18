using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.PostulantSystem;
using jobagapi.Domain.Services.Communication.PostulantResponse;

namespace jobagapi.Domain.Services.PostulantServices
{
    public interface IProfileLanguageService
    {
        Task<IEnumerable<ProfileLanguage>> ListAsync();
        Task<IEnumerable<ProfileLanguage>> ListByProfileIdAsync(int profileId);
        Task<IEnumerable<ProfileLanguage>> ListByLanguageIdAsync(int languageId);
        Task<ProfileLanguageResponse> AssignProfileLanguageAsync(int profileId, int languageId);
        Task<ProfileLanguageResponse> UnassignProfileLanguageAsync(int profileId, int languageId);
    }
}