using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using jobagapi.Domain.Models.PostulantSystem;
using jobagapi.Domain.Services.PostulantServices;
using jobagapi.Resources.PostulantResources;
using Microsoft.AspNetCore.Mvc;

namespace jobagapi.Controllers.PostulantControllers
{
    [Route("/api/v1/professional-profiles/{profileId}/degrees")]
    public class ProfileDegreesController: ControllerBase
    {
        private readonly IDegreeService _degreeService;
        private readonly IProfileDegreeService _profileDegree;
        private readonly IMapper _mapper;

        public ProfileDegreesController(IDegreeService degreeService, IProfileDegreeService profileDegree, IMapper mapper)
        {
            _degreeService = degreeService;
            _profileDegree = profileDegree;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<DegreeResource>> GetAllByProfileIdAsync(int profileId)
        {
            var degrees = await _degreeService.ListByProfileIdAsync(profileId);
            var resources = _mapper.Map<IEnumerable<Degree>, IEnumerable<DegreeResource>>(degrees);

            return resources;
        }

        [HttpPost("{degreeId}")]
        public async Task<IActionResult> AssignProfileDegree(int profileId, int degreeId)
        {
            var result = await _profileDegree.AssignProfileDegreeAsync(profileId, degreeId);

            if (!result.Success)
                return BadRequest(result.Message);

            var degreeResource = _mapper.Map<Degree, DegreeResource>(result.Resource.Degree);

            return Ok(degreeResource);
        } 
    }
}