using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.PostulantSystem;

namespace jobagapi.Domain.Repositories.PostulantRepositories
{
    public interface IProfessionalRepository
    {
        Task AddAsync(ProfessionalProfile profile);
        Task<ProfessionalProfile> FindById(int id);
        
        void Update(ProfessionalProfile professionalProfile);
        void Remove(ProfessionalProfile profile);
        Task<IEnumerable<ProfessionalProfile>> ListAsync();
 
    }
}