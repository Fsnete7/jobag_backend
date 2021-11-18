using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using jobagapi.Domain.Models.PostulantSystem;
using jobagapi.Domain.Services.PostulantServices;
using jobagapi.Resources.PostulantResources;
using Microsoft.AspNetCore.Mvc;
 

namespace jobagapi.Controllers.PostulantControllers
{
    [Route("/api/v1/professional-profiles/{profileId}/languages")]
    public class ProfileLanguagesController: ControllerBase
    {
        private readonly ILanguageService _languageService;
        private readonly IProfileLanguageService _profileLanguageService;
        private readonly IMapper _mapper;
 

        public ProfileLanguagesController(IMapper mapper, ILanguageService languageService, IProfileLanguageService profileLanguageService)
        {
            _mapper = mapper;
            _languageService = languageService;
            _profileLanguageService = profileLanguageService;
        }

        [HttpGet]
        public async Task<IEnumerable<LanguageResource>> GetAllByProfileIdAsync(int profileId)
        {
            var languages = await _languageService.ListByProfileIdAsync(profileId);
            var resources = _mapper.Map<IEnumerable<Language>, IEnumerable<LanguageResource>>(languages);

            return resources;
        }

        [HttpPost("{languageId}")]
        public async Task<IActionResult> AssignProfileDegree(int profileId, int languageId)
        {
            var result = await _profileLanguageService.AssignProfileLanguageAsync(profileId, languageId);

            if (!result.Success)
                return BadRequest(result.Message);

            var languageResource = _mapper.Map<Language, LanguageResource>(result.Resource.Language);

            return Ok(languageResource);
        }  
    }
}