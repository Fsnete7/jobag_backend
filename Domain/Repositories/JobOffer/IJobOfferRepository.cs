

using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models;

namespace jobagapi.Domain.Repositories
{
    public interface IJobOfferRepository
    {
        Task<IEnumerable<JobOffer>> ListAsync();
    }
}