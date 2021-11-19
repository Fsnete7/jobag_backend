using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using jobagapi.Domain.Models;
using jobagapi.Domain.Models.JobOfferSystem;
using jobagapi.Domain.Services;
using jobagapi.Extensions;
using jobagapi.Resources;
using jobagapi.Resources.JobOfferResources;
using Microsoft.AspNetCore.Mvc;

namespace jobagapi.Controllers
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
        public async Task<IEnumerable<PostulationResource>> GetAllAsync()
        {
            var postulations = await _postulationService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Postulation>, IEnumerable<PostulationResource>>(postulations);
            return resources;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] SavePostulationResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var postulation = _mapper.Map<SavePostulationResource, Postulation>(resource);
            var result = await _postulationService.SaveAsync(postulation);

            if (!result.Success)
                return BadRequest(result.Message);

            var postulationResource = _mapper.Map<Postulation, SavePostulationResource>(result.Resource);
            return Ok(postulationResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SavePostulationResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var postulation = _mapper.Map<SavePostulationResource, Postulation>(resource);
            var result = await _postulationService.UpdateAsync(id, postulation);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var postulationResource = _mapper.Map<Postulation, SavePostulationResource>(result.Resource);
            return Ok(postulationResource);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _postulationService.DeletAsync(id);
               
            if (!result.Success)
                return BadRequest(result.Message);

            var postulationResource = _mapper.Map<Postulation, SavePostulationResource>(result.Resource);
            return Ok(postulationResource);
        }
    }
    
}