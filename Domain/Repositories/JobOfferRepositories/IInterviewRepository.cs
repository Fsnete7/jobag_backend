using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models;
using jobagapi.Domain.Models.JobOfferSystem;

namespace jobagapi.Domain.Repositories
{
    public interface IInterviewRepository
    {
        Task<IEnumerable<Interview>> ListAsync();
        Task AddAsync(Interview interview);

        Task<Interview> FindByIdAsync(int id);

        void Update(Interview interview);

        void Remove(Interview interview);
        
        Task<IEnumerable<Interview>> ListByJobOfferIdAsync(int jobOfferId);
        Task<IEnumerable<Interview>> ListByPostulantIdAsync(int postulantId);
        Task<Interview> FindByJobOfferIdAndPostulantId(int jobOfferId, int postulantId);
    }
}