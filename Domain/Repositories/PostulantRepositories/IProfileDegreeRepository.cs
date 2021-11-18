using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.PostulantSystem;

namespace jobagapi.Domain.Repositories.PostulantRepositories
{
    public interface IProfileDegreeRepository
    {
        Task<IEnumerable<ProfileDegree>> ListAsync();
        Task<IEnumerable<ProfileDegree>> ListByProfileIdAsync(int profileId);
        Task<IEnumerable<ProfileDegree>> ListByDegreeIdAsync(int degreeId);
        Task<ProfileDegree> FindByProfileIdAndDegreeId(int profileId, int degreeId);
        Task AddAsync(ProfileDegree profileDegree);
        void Remove(ProfileDegree profileDegree);
        Task AssignProfileDegree(int profileId, int degreeId);
        Task UnassignProfileDegree(int profileId, int degreeId);
    }
}