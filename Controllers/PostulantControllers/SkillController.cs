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
    public class SkillController: ControllerBase
    {
         private readonly ISkillService _skillService;

        private readonly IMapper _mapper;

        public SkillController(ISkillService skillService, IMapper mapper)
        {
            _skillService = skillService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<SkillResource>> GetAllAsync()
        {
            var skills = await _skillService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Skill>, IEnumerable<SkillResource>>(skills);
            return resources;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] SaveSkillResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var skill = _mapper.Map<SaveSkillResource, Skill>(resource);
            var result = await _skillService.SaveAsync(skill);

            if (!result.Success)
                return BadRequest(result.Message);

            var skillResource = _mapper.Map<Skill, SkillResource>(result.Resource);
            return Ok(skillResource);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveSkillResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var skill = _mapper.Map<SaveSkillResource, Skill>(resource);
            var result = await _skillService.UpdateAsync(id, skill);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var skillResource = _mapper.Map<Skill, SkillResource>(result.Resource);
            return Ok(skillResource);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _skillService.DeleteAsync(id);
               
            if (!result.Success)
                return BadRequest(result.Message);
            
            var skillResource = _mapper.Map<Skill, SkillResource>(result.Resource);
            return Ok(skillResource);
        }
    }
}