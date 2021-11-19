using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.JobOfferSystem;
using jobagapi.Domain.Services.Communication.JobOfferResponse;

namespace jobagapi.Domain.Services.JobOfferServices
{
    public interface IPostulationService
    {
        // GET
        Task<IEnumerable<Postulation>> ListAsync();
        // POST
        Task<SavePostulationResponse> SaveAsync(Postulation postulation);
        // UPDATE
        Task<SavePostulationResponse> UpdateAsync(int id, Postulation postulation);
        // DELETE
        Task<PostulationResponse> DeleteAsync(int id);
        
        Task<IEnumerable<Postulation>> ListByPostulantIdAsync(int postulantId);
        Task<IEnumerable<Postulation>> ListByOfferIdAsync(int offerId);
       
    }
}