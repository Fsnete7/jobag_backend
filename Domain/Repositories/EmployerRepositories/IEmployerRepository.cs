using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.EmployerSystem;

namespace jobagapi.Domain.Repositories.EmployerRepositories
{
    public interface IEmployerRepository
    {
        
        Task<IEnumerable<Employer>> ListAsync();
        Task AddAsync(Employer employer);

        Task<Employer> FindByIdAsync(int id);

        void Update(Employer employer);

        void Delete(Employer employer);
    }
}