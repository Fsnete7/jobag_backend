using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.PostulantSystem;
using jobagapi.Domain.Services.Communication.PostulantResponse;

namespace jobagapi.Domain.Services.PostulantServices
{
    public interface IProfessionalProfileService
    {
        Task<ProfessionalProfileResponse> GetByIdAsync(int id);
        Task<ProfessionalProfileResponse> SaveAsync(ProfessionalProfile professionalProfile);
        Task<IEnumerable<ProfessionalProfile>> ListAsync();
        Task<ProfessionalProfileResponse> DeleteAsync(int id);
    }
}