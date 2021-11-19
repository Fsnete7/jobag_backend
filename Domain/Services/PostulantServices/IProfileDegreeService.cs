using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.PostulantSystem;
using jobagapi.Domain.Services.Communication.PostulantResponse;

namespace jobagapi.Domain.Services.PostulantServices
{
    public interface IProfileDegreeService
    {
        Task<IEnumerable<ProfileDegree>> ListAsync();
        Task<IEnumerable<ProfileDegree>> ListByProfileIdAsync(int profileId);
        Task<IEnumerable<ProfileDegree>> ListByDegreeIdAsync(int degreeId);
        Task<ProfileDegreeResponse> AssignProfileDegreeAsync(int profileId, int degreeId);
        Task<ProfileDegreeResponse> UnassignProfileDegreeAsync(int profileId, int degreeId);
    }
}