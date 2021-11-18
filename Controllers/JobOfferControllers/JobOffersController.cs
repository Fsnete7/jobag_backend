using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using jobagapi.Domain.Models.JobOfferSystem;
using jobagapi.Domain.Services.JobOfferServices;
using jobagapi.Extensions;
using jobagapi.Resources.JobOfferResources;
using Microsoft.AspNetCore.Mvc;

namespace jobagapi.Controllers.JobOfferControllers
{
    [Route("/api/v1/[controller]")]
    public class JobOffersController : ControllerBase
    {
        private readonly IJobOfferService _jobOfferService;
        private readonly IMapper _mapper;

        public JobOffersController(IJobOfferService jobOfferService, IMapper mapper)
        {
            _jobOfferService = jobOfferService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<jobOfferResource>> GetAllAsync()
        {
            var jobOffers = await _jobOfferService.ListAsync();
            var resources = _mapper.Map<IEnumerable<JobOffer>, IEnumerable<jobOfferResource>>(jobOffers);
            return resources;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] SaveJobOfferResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var jobOffer = _mapper.Map<SaveJobOfferResource, JobOffer>(resource);
            var result = await _jobOfferService.SaveAsync(jobOffer);

            if (!result.Success)
                return BadRequest(result.Message);

            var jobOfferResource = _mapper.Map<JobOffer, SaveJobOfferResource>(result.Resource);
            return Ok(jobOfferResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveJobOfferResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var jobOffer = _mapper.Map<SaveJobOfferResource, JobOffer>(resource);
            var result = await _jobOfferService.UpdateAsync(id, jobOffer);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var jobOfferResource = _mapper.Map<JobOffer, SaveJobOfferResource>(result.Resource);
            return Ok(jobOfferResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _jobOfferService.DeletAsync(id);
               
            if (!result.Success)
                return BadRequest(result.Message);

            var jobOfferResource = _mapper.Map<JobOffer, SaveJobOfferResource>(result.Resource);
            return Ok(jobOfferResource);
        }
    }
}