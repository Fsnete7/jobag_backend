using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.JobOfferSystem;

namespace jobagapi.Domain.Repositories.JobOfferRepositories
{
    public interface IPostulationRepository
    {
        Task<IEnumerable<Postulation>> ListAsync();
        
        Task AddAsync(Postulation postulation);

        Task<Postulation> FindByIdAsync(int id);

        void Update(Postulation postulation);

        void Remove(Postulation postulation);
        
      
        Task<IEnumerable<Postulation>> ListByJobOfferIdAsync(int jobOfferId);
        Task<IEnumerable<Postulation>> ListByPostulantIdAsync(int postulantId);
        Task<Postulation> FindByJobOfferIdAndPostulantId(int jobOfferId, int postulantId);
       
    }
}