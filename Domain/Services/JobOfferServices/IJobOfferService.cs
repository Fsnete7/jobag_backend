using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.JobOfferSystem;
using jobagapi.Domain.Services.Communication.JobOfferResponse;

namespace jobagapi.Domain.Services.JobOfferServices
{
    public interface IJobOfferService
    {
        Task<IEnumerable<JobOffer>> ListAsync();

        Task<JobOfferResponse> SaveAsync(JobOffer jobOffer);

        Task<JobOfferResponse> UpdateAsync(int id, JobOffer jobOffer);

        Task<JobOfferResponse> DeletAsync(int id);
    }
}