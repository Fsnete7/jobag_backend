using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models;

namespace jobagapi.Domain.Services
{
    public interface IJobOfferService
    {
        Task<IEnumerable<JobOffer>> ListAsync();
    }
}