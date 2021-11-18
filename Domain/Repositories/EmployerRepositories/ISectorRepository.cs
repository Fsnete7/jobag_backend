using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.EmployerSystem;

namespace jobagapi.Domain.Repositories.EmployerRepositories
{
    public interface ISectorRepository
    {
        Task<IEnumerable<Sector>> ListAsync();
        
        Task AddAsync(Sector sector);
        
        Task<Sector> FindByIdAsync(int id);

        void Delete(Sector sector);
        
        
    }
}