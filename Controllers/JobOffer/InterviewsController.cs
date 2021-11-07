using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using jobagapi.Domain.Models;
using jobagapi.Domain.Services;
using jobagapi.Domain.Services.Communication.JobOffer;
using jobagapi.Extensions;
using jobagapi.Resources;
using Microsoft.AspNetCore.Mvc;

namespace jobagapi.Controllers
{
    [Route("/api/v1/[controller]")]
    public class InterviewsController : ControllerBase
    {
        private readonly IInterviewService _interviewService;
        private readonly IMapper _mapper;

        public InterviewsController(IInterviewService interviewService, IMapper mapper)
        {
            _interviewService = interviewService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<interviewResource>> GetAllAsync()
        {
            var interviews = await _interviewService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Interview>, IEnumerable<interviewResource>>(interviews);
            return resources;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] SaveInterviewResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var interview = _mapper.Map<SaveInterviewResource, Interview>(resource);
            var result = await _interviewService.SaveAsync(interview);

            if (!result.Succes)
                return BadRequest(result.Message);

            var interviewResource = _mapper.Map<Interview, SaveInterviewResource>(result.Interview);
            return Ok(interviewResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveInterviewResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var interview = _mapper.Map<SaveInterviewResource, Interview>(resource);
            var result = await _interviewService.UpdateAsync(id, interview);
            
            if (!result.Succes)
                return BadRequest(result.Message);

            var interviewResource = _mapper.Map<Interview, SaveInterviewResource>(result.Interview);
            return Ok(interviewResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _interviewService.DeletAsync(id);
               
            if (!result.Succes)
                return BadRequest(result.Message);

            var interviewResource = _mapper.Map<Interview, SaveInterviewResource>(result.Interview);
            return Ok(interviewResource);
        }
    }
}