using System.Collections.Generic;
using System.Threading.Tasks;

namespace jobagapi.Domain.Repositories.Employer
{
    public interface IEmployerRepository
    {
        
        Task<IEnumerable<Models.Employer>> ListAsync();
    }
}