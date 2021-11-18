using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.PostulantSystem;
using jobagapi.Domain.Services.Communication.PostulantResponse;

namespace jobagapi.Domain.Services.PostulantServices
{
    public interface IDegreeService
    {
        Task<IEnumerable<Degree>> ListByProfileIdAsync(int profileId);
        Task<DegreeResponse> SaveAsync(Degree degree);
        Task<IEnumerable<Degree>> ListAsync();
        Task<DegreeResponse> DeleteAsync(int id);
        
        Task<DegreeResponse> UpdateAsync(int id, Degree degree);
    }
}