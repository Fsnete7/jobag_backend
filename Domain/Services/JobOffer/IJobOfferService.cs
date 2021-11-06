using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models;
using jobagapi.Domain.Services.Communication.JobOffer;
using jobagapi.Resources;

namespace jobagapi.Domain.Services
{
    public interface IJobOfferService
    {
        Task<IEnumerable<JobOffer>> ListAsync();

        Task<SaveJobOfferResponse> SaveAsync(JobOffer jobOffer);

        Task<SaveJobOfferResponse> UpdateAsync(int id, JobOffer jobOffer);

        Task<JobOfferResponse> DeletAsync(int id);
    }
}