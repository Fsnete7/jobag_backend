using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models;
using jobagapi.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace jobagapi.Controllers
{
    [Route("/api/v1/[controller]")]
    public class JobOffersController : ControllerBase
    {
        private readonly IJobOfferService _jobOfferService;

        public JobOffersController(IJobOfferService jobOfferService)
        {
            _jobOfferService = jobOfferService;
        }

        public async Task<IEnumerable<JobOffer>> GetAllAsync()
        {
            var jobOffers = await _jobOfferService.ListAsync();
            return jobOffers;
        }
    }
}