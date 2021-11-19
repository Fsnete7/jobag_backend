using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using jobagapi.Domain.Models.PostulantSystem;
using jobagapi.Domain.Services.PostulantServices;
using jobagapi.Resources.PostulantResources;
using Microsoft.AspNetCore.Mvc;

namespace jobagapi.Controllers.PostulantControllers
{
    [Route("/api/v1/professional-profiles/{profileId}/skills")]
    public class ProfileSkillsController: ControllerBase
    {
        private readonly ISkillService _skillService;
        private readonly IProfileSkillService _profileSkillService;
        private readonly IMapper _mapper;

        public ProfileSkillsController(IProfileSkillService profileSkillService, IMapper mapper, ISkillService skillService)
        {
 
            _profileSkillService = profileSkillService;
            _mapper = mapper;
            _skillService = skillService;
        }

        [HttpGet]
        public async Task<IEnumerable<SkillResource>> GetAllByProfileIdAsync(int profileId)
        {
            var skills = await _skillService.ListByProfileIdAsync(profileId);
            var resources = _mapper.Map<IEnumerable<Skill>, IEnumerable<SkillResource>>(skills);

            return resources;
        }

        [HttpPost("{skillId}")]
        public async Task<IActionResult> AssignProfileSkill(int profileId, int skillId)
        {
            var result = await _profileSkillService.AssignProfileSkillAsync(profileId, skillId);

            if (!result.Success)
                return BadRequest(result.Message);

            var skillResource = _mapper.Map<Skill, SkillResource>(result.Resource.Skill);

            return Ok(skillResource);
        }   
    }
}