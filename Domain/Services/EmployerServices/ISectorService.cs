using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.EmployerSystem;

namespace jobagapi.Domain.Services.EmployerServices
{
    public interface ISectorService
    {
        
        Task<IEnumerable<Sector>> ListAsync();
    }
}