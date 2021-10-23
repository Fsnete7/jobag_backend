using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models;
using jobagapi.Domain.Repositories;
using jobagapi.Domain.Services;

namespace jobagapi.Services
{
    public class JobOfferService : IJobOfferService
    {
        private readonly IJobOfferRepository _jobOfferRepository;

        public JobOfferService(IJobOfferRepository jobOfferRepository)
        {
            _jobOfferRepository = jobOfferRepository;
        }

        public async Task<IEnumerable<JobOffer>> ListAsync()
        {
            return await _jobOfferRepository.ListAsync();
        }
    }
}