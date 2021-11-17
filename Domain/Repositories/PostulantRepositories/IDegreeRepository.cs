using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.PostulantSystem;
using jobagapi.Domain.Services.Communication.PostulantResponse;

namespace jobagapi.Domain.Repositories.PostulantRepositories
{
    public interface IDegreeRepository
    {
        Task AddAsync(Degree degree);
        void Remove(Degree degree);
        Task AssignDegree(int profileId, int degreeId);
        void UnassignDegree(int profileId, int degreeId);
        Task<Degree> FindById(int id);
        Task<IEnumerable<Degree>> ListAsync();
    }
}