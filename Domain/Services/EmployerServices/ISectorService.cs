using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.EmployerSystem;
using jobagapi.Domain.Services.Communication.EmployerResponse;

namespace jobagapi.Domain.Services.EmployerServices
{
    public interface ISectorService
    {
        
        Task<IEnumerable<Sector>> ListAsync();
        Task<SectorResponse> SaveAsync(Sector sector);

      
        Task<SectorResponse> DeletAsync(int id);
    }
}