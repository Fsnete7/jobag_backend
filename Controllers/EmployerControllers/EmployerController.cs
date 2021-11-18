using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using jobagapi.Domain.Models.EmployerSystem;
using jobagapi.Domain.Services.EmployerServices;
using Microsoft.AspNetCore.Mvc;
using jobagapi.Extensions;
using jobagapi.Resources.EmployerResources;

namespace jobagapi.Controllers.EmployerControllers
{
    [Route("/api/v1/[controller]")]
    public class EmployerController : ControllerBase
    {
        private readonly IEmployerService _employerService;
        private readonly IMapper _mapper;

        public EmployerController(IEmployerService employerService, IMapper mapper)
        {
            _employerService = employerService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<EmployerResource>> GetAllAsync()
        {
            var employers = await _employerService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Employer>, IEnumerable<EmployerResource>>(employers);
            return resources;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] SaveEmployerResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var employer = _mapper.Map<SaveEmployerResource, Employer>(resource);
            var result = await _employerService.SaveAsync(employer);

            if (!result.Success)
                return BadRequest(result.Message);
            var employerResource = _mapper.Map<Employer, SaveEmployerResource>(result.Resource);
            return Ok(employerResource);
        }
        
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveEmployerResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var employer = _mapper.Map<SaveEmployerResource, Employer>(resource);
            var result = await _employerService.UpdateAsync(id, employer);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var employerResource = _mapper.Map<Employer, SaveEmployerResource>(result.Resource);
            return Ok(employerResource);
        } 
        
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _employerService.DeletAsync(id);
               
            if (!result.Success)
                return BadRequest(result.Message);

            var employerResource = _mapper.Map<Employer, SaveEmployerResource>(result.Resource);
            return Ok(employerResource);
        }
    }
}