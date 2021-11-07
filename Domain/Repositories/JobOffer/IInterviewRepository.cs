using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models;

namespace jobagapi.Domain.Repositories
{
    public interface IInterviewRepository
    {
        Task<IEnumerable<Interview>> ListAsync();
        Task AddAsync(Interview interview);

        Task<Interview> FindByIdAsync(int id);

        void update(Interview interview);

        void Delete(Interview interview);
    }
}