using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using jobagapi.Domain.Models.JobOfferSystem;
using jobagapi.Domain.Models.PostulantSystem;
using jobagapi.Domain.Services.PostulantServices;
using jobagapi.Extensions;
using jobagapi.Resources.JobOfferResources;
using jobagapi.Resources.PostulantResources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace jobagapi.Controllers.PostulantControllers
{
    [Route("/api/v1/[controller]")]
    public class PostulantController: ControllerBase
    {
         private readonly IPostulantService _postulantService;
        private readonly IMapper _mapper;

        public PostulantController(IPostulantService postulantService, IMapper mapper)
        {
            _postulantService = postulantService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<PostulantResource>> GetAllAsync()
        {
            var postulants = await _postulantService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Postulant>, IEnumerable<PostulantResource>>(postulants);
            return resources;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] SavePostulantResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var postulant = _mapper.Map<SavePostulantResource, Postulant>(resource);
            var result = await _postulantService.SaveAsync(postulant);

            if (!result.Success)
                return BadRequest(result.Message);

            var postulantResource = _mapper.Map<Postulant, PostulantResource>(result.Resource);
            return Ok(postulantResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SavePostulantResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var postulant = _mapper.Map<SavePostulantResource, Postulant>(resource);
            var result = await _postulantService.UpdateAsync(id, postulant);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var postulantResource = _mapper.Map<Postulant, PostulantResource>(result.Resource);
            return Ok(postulantResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _postulantService.DeleteAsync(id);
               
            if (!result.Success)
                return BadRequest(result.Message);

            var postulantResource = _mapper.Map<Postulant, PostulantResource>(result.Resource);
            return Ok(postulantResource);
        }
    }
}