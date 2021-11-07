using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models;

namespace jobagapi.Domain.Repositories
{
    public interface IPostulationRepository
    {
        Task<IEnumerable<Postulation>> ListAsync();
        Task AddAsync(Postulation postulation);

        Task<Postulation> FindByIdAsync(int id);

        void update(Postulation postulation);

        void Delete(Postulation postulation);
    }
}