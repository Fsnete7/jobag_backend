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
        void Update(Degree degree);
        Task<Degree> FindById(int id);
        Task<IEnumerable<Degree>> ListAsync();
    }
}