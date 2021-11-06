

using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models;

namespace jobagapi.Domain.Repositories
{
    public interface IJobOfferRepository
    {
        Task<IEnumerable<JobOffer>> ListAsync();
        Task AddAsync(JobOffer jobOffer);

        Task<JobOffer> FindByIdAsync(int id);

        void update(JobOffer jobOffer);

        void Delete(JobOffer jobOffer);
    }
}