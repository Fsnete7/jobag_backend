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
    public class ProfessionalProfileController: ControllerBase
    {
         private readonly IProfessionalProfileService _profileService;

        private readonly IMapper _mapper;

        public ProfessionalProfileController(IProfessionalProfileService profileService, IMapper mapper)
        {
            _profileService = profileService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProfessionalProfileResource>> GetAllAsync()
        {
            var profiles = await _profileService.ListAsync();
            var resources = _mapper.Map<IEnumerable<ProfessionalProfile>, IEnumerable<ProfessionalProfileResource>>(profiles);
            return resources;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] SaveProfessionalProfileResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var profile = _mapper.Map<SaveProfessionalProfileResource, ProfessionalProfile>(resource);
            var result = await _profileService.SaveAsync(profile);

            if (!result.Success)
                return BadRequest(result.Message);

            var profileResource = _mapper.Map<ProfessionalProfile, ProfessionalProfileResource>(result.Resource);
            return Ok(profileResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveProfessionalProfileResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var profile = _mapper.Map<SaveProfessionalProfileResource, ProfessionalProfile>(resource);
            var result = await _profileService.UpdateAsync(id ,profile);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var profileResource = _mapper.Map<ProfessionalProfile, ProfessionalProfileResource>(result.Resource);
            return Ok(profileResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _profileService.DeleteAsync(id);
               
            if (!result.Success)
                return BadRequest(result.Message);
            
            var profileResource = _mapper.Map<ProfessionalProfile, ProfessionalProfileResource>(result.Resource);
            return Ok(profileResource);
        }
    }
}