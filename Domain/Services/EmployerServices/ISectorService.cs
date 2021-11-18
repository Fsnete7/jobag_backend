using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.EmployerSystem;
using jobagapi.Domain.Services.Communication.EmployerResponse;

namespace jobagapi.Domain.Services.EmployerServices
{
    public interface ISectorService
    {
        
        Task<IEnumerable<Sector>> ListAsync();
        Task<SaveSectorResponse> SaveAsync(Sector sector);

        Task<SaveSectorResponse> UpdateAsync(int id, Sector sector);

        Task<SectorResponse> DeleteAsync(int id);
    }
}