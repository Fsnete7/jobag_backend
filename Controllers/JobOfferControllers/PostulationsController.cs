using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using jobagapi.Domain.Models.JobOfferSystem;
using Microsoft.AspNetCore.Mvc;
using jobagapi.Domain.Services.JobOfferServices;
using jobagapi.Extensions;
using jobagapi.Resources.JobOfferResources;

namespace jobagapi.Controllers.JobOfferControllers
{
    [Route("/api/v1/[controller]")]
    public class PostulationsController : ControllerBase
    {
        private readonly IPostulationService _postulationService;
        private readonly IMapper _mapper;
        
        public PostulationsController(IPostulationService postulationService, IMapper mapper)
        {
            _postulationService = postulationService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<PostulationResource>> GetAllList()
        {
            var postulations = await _postulationService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Postulation>, IEnumerable<PostulationResource>>(postulations);
            return resources;
        }
        
        [HttpGet]
        [Route("/api/v1/joboffer/{jobOfferId}/[controller]")]
        public async Task<IEnumerable<PostulationResource>> GetAllPostulationsByJobOfferId(int jobOfferId)
        {
            var postulations = await _postulationService.ListByOfferIdAsync(jobOfferId);
            var resources = _mapper.Map<IEnumerable<Postulation>, IEnumerable<PostulationResource>>(postulations);
            return resources;
        }
        
        [HttpGet]
        [Route("/api/v1/postulant/{postulantId}/[controller]")]
        public async Task<IEnumerable<PostulationResource>> GetAllPostulationsByPostulantId(int postulantId)
        {
            var postulations = await _postulationService.ListByPostulantIdAsync(postulantId);
            var resources = _mapper.Map<IEnumerable<Postulation>, IEnumerable<PostulationResource>>(postulations);
            return resources;
        }
        
        
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SavePostulationResource resource) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var postulations = _mapper.Map<SavePostulationResource, Postulation>(resource);
            var result = await _postulationService.SaveAsync(postulations);

            if (!result.Success)
                return BadRequest(result.Message);

            var postulationResource = _mapper.Map<Postulation, PostulationResource>(result.Resource);

            return Ok(postulationResource);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SavePostulationResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
            
            var postulations= _mapper.Map<SavePostulationResource, Postulation>(resource);
            var result = await _postulationService.UpdateAsync(id, postulations);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var postulationResource = _mapper.Map<Postulation, PostulationResource>(result.Resource);

            return Ok(postulationResource);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _postulationService.DeleteAsync(id);
            if (!result.Success)
                return BadRequest(result.Message);

            var postulationResource = _mapper.Map<Postulation, PostulationResource>(result.Resource);

            return Ok(postulationResource);
        }
    }
}