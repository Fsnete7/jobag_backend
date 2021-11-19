using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models;
using jobagapi.Domain.Models.JobOfferSystem;
using jobagapi.Domain.Services.Communication.JobOfferResponse;

namespace jobagapi.Domain.Services
{
    public interface IInterviewService
    {
        Task<IEnumerable<Interview>> ListAsync();

        Task<SaveInterviewResponse> SaveAsync(Interview interview);

        Task<SaveInterviewResponse> UpdateAsync(int id, Interview interview);

        Task<InterviewResponse> DeleteAsync(int id);  
        
        
        
        Task<IEnumerable<Interview>> ListByPostulantId(int postulantId);
        Task<IEnumerable<Interview>> ListByOfferIdAsync(int offerId);
    }
}