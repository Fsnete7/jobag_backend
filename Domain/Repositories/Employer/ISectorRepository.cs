using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models;

namespace jobagapi.Domain.Repositories.Employer
{
    public interface ISectorRepository
    {
        
        Task<IEnumerable<Sector>> ListAsync();
    }
}