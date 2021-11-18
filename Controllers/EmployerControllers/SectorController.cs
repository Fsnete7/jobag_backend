using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using jobagapi.Domain.Models.EmployerSystem;
using jobagapi.Domain.Services.EmployerServices;
using jobagapi.Extensions;
using jobagapi.Resources.EmployerResources;
using Microsoft.AspNetCore.Mvc;

namespace jobagapi.Controllers.EmployerControllers
{
    [Route("/api/v1/[controller]")]
    public class SectorController : ControllerBase
    {
        private readonly ISectorService _sectorService;
        private readonly IMapper _mapper;
        
        public SectorController(ISectorService sectorService, IMapper mapper)
        {
            _sectorService = sectorService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<SectorResource>> GetAllAsync()
        {
            var sectors = await _sectorService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Sector>, IEnumerable<SectorResource>>(sectors);
            return resources;
        }
        
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] SaveSectorResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var sector = _mapper.Map<SaveSectorResource, Sector>(resource);
            var result = await _sectorService.SaveAsync(sector);

            if (!result.Success)
                return BadRequest(result.Message);
            var sectorResource = _mapper.Map<Sector, SectorResource>(result.Resource);
            return Ok(sectorResource);
        }
        
        
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveSectorResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var sector = _mapper.Map<SaveSectorResource, Sector>(resource);
            var result = await _sectorService.UpdateAsync(id, sector);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var sectorResource = _mapper.Map<Sector, SectorResource>(result.Resource);
            return Ok(sectorResource);
        } 
      
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _sectorService.DeleteAsync(id);
               
            if (!result.Success)
                return BadRequest(result.Message);

            var sectorResource = _mapper.Map<Sector, SectorResource>(result.Resource);
            return Ok(sectorResource);
        }
    }
}