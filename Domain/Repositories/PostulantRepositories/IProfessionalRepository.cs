using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.PostulantSystem;

namespace jobagapi.Domain.Repositories.PostulantRepositories
{
    public interface IProfessionalRepository
    {
        Task AddAsync(ProfessionalProfile profile);
        Task<ProfessionalProfile> FindById(int id);
        void Remove(ProfessionalProfile profile);
        Task<IEnumerable<ProfessionalProfile>> ListAsync();
        Task<ProfessionalProfile> FindByPostulantIdAndProfileId(int postulantId, int profileId);
    }
}