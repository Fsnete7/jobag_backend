using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
<<<<<<< HEAD:Controllers/JobOfferControllers/PostulationsController.cs
using jobagapi.Domain.Models.JobOfferSystem;
=======
using jobagapi.Domain.Models;
using jobagapi.Domain.Models.JobOfferSystem;
using jobagapi.Domain.Services;
using jobagapi.Extensions;
using jobagapi.Resources;
using jobagapi.Resources.JobOfferResources;
>>>>>>> main:Controllers/JobOffer/PostulationsController.cs
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
<<<<<<< HEAD:Controllers/JobOfferControllers/PostulationsController.cs
        public async Task<IEnumerable<PostulationResource>> GetAllList()
=======
        public async Task<IEnumerable<PostulationResource>> GetAllAsync()
>>>>>>> main:Controllers/JobOffer/PostulationsController.cs
        {
            var postulations = await _postulationService.ListAsync();
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

<<<<<<< HEAD:Controllers/JobOfferControllers/PostulationsController.cs
            var postulationResource = _mapper.Map<Postulation, PostulationResource>(result.Resource);

=======
            var postulationResource = _mapper.Map<Postulation, SavePostulationResource>(result.Resource);
>>>>>>> main:Controllers/JobOffer/PostulationsController.cs
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

<<<<<<< HEAD:Controllers/JobOfferControllers/PostulationsController.cs
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

=======
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
>>>>>>> main:Controllers/JobOffer/PostulationsController.cs
            return Ok(postulationResource);
        }
    }
    
}