using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.EmployerSystem;

namespace jobagapi.Domain.Repositories.EmployerRepositories
{
    public interface IEmployerRepository
    {
        Task<IEnumerable<Models.EmployerSystem.Employer>> ListAsync();
    }
}