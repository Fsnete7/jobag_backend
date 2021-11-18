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
    public class LanguageController: ControllerBase
    {
         private readonly ILanguageService _languageService;
        private readonly IMapper _mapper;

        public LanguageController(ILanguageService languageService, IMapper mapper)
        {
            _languageService = languageService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<LanguageResource>> GetAllAsync()
        {
            var languages = await _languageService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Language>, IEnumerable<LanguageResource>>(languages);
            return resources;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] SaveLanguageResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var language = _mapper.Map<SaveLanguageResource, Language>(resource);
            var result = await _languageService.SaveAsync(language);

            if (!result.Success)
                return BadRequest(result.Message);

            var languageResource = _mapper.Map<Language, LanguageResource>(result.Resource);
            return Ok(languageResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveLanguageResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var language = _mapper.Map<SaveLanguageResource, Language>(resource);
            var result = await _languageService.UpdateAsync(id, language);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var languageResource = _mapper.Map<Language, LanguageResource>(result.Resource);
            return Ok(languageResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _languageService.DeleteAsync(id);
               
            if (!result.Success)
                return BadRequest(result.Message);

            var languageResource = _mapper.Map<Language, SaveLanguageResource>(result.Resource);
            return Ok(languageResource);
        }
    }
}