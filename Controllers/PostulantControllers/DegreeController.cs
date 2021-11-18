using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using jobagapi.Domain.Models.PostulantSystem;
using jobagapi.Domain.Services.Communication.PostulantResponse;
using jobagapi.Domain.Services.PostulantServices;
using jobagapi.Extensions;
using jobagapi.Resources.PostulantResources;
using Microsoft.AspNetCore.Mvc;

namespace jobagapi.Controllers.PostulantControllers
{
    [Route("/api/v1/[controller]")]
    public class DegreeController: ControllerBase
    {
        private readonly IDegreeService _degreeService;

        private readonly IMapper _mapper;

        public DegreeController(IDegreeService degreeService, IMapper mapper)
        {
            _degreeService = degreeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<DegreeResource>> GetAllAsync()
        {
            var degrees = await _degreeService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Degree>, IEnumerable<DegreeResource>>(degrees);
            return resources;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] SaveDegreeResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var degree = _mapper.Map<SaveDegreeResource, Degree>(resource);
            var result = await _degreeService.SaveAsync(degree);

            if (!result.Success)
                return BadRequest(result.Message);

            var degreeResource = _mapper.Map<Degree, DegreeResource>(result.Resource);
            return Ok(degreeResource);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveDegreeResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var degree = _mapper.Map<SaveDegreeResource, Degree>(resource);
            var result = await _degreeService.UpdateAsync(id,degree);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var degreeResource = _mapper.Map<Degree, DegreeResource>(result.Resource);
            return Ok(degreeResource);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _degreeService.DeleteAsync(id);
               
            if (!result.Success)
                return BadRequest(result.Message);
            
            var degreeResource = _mapper.Map<Degree, DegreeResource>(result.Resource);
            return Ok(degreeResource);
        }
        
    }
}