using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using jobagapi.Domain.Models.EmployerSystem;
using jobagapi.Domain.Repositories.EmployerRepositories;
using jobagapi.Domain.Services.EmployerServices;
using Microsoft.AspNetCore.Mvc;
using jobagapi.Extensions;
using jobagapi.Resources.EmployerResources;

namespace jobagapi.Controllers.EmployerControllers
{
    [Route("/api/v1/[controller]")]
    public class CompanyProfileController : ControllerBase
    {
        private readonly ICompanyProfileService _companyProfileService;
        private readonly IMapper _mapper;

        public CompanyProfileController(ICompanyProfileService companyProfileService, IMapper mapper)
        {
            _companyProfileService = companyProfileService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CompanyProfileResource>> GetAllAsync()
        {
            var companyProfiles = await _companyProfileService.ListAsync();
            var resources = _mapper.Map<IEnumerable<CompanyProfile>, IEnumerable<CompanyProfileResource>>(companyProfiles);
            return resources;
        }
        
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] SaveCompanyProfileResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var companyProfile = _mapper.Map<SaveCompanyProfileResource, CompanyProfile>(resource);
            var result = await _companyProfileService.SaveAsync(companyProfile);

            if (!result.Success)
                return BadRequest(result.Message);
            var companyProfileResource = _mapper.Map<CompanyProfile, CompanyProfileResource>(result.Resource);
            return Ok(companyProfileResource);
        }
        
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCompanyProfileResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var companyProfile = _mapper.Map<SaveCompanyProfileResource, CompanyProfile>(resource);
            var result = await _companyProfileService.UpdateAsync(id, companyProfile);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var companyProfileResource = _mapper.Map<CompanyProfile, CompanyProfileResource>(result.Resource);
            return Ok(companyProfileResource);
        } 
        
        [HttpDelete("{id:int}")]
        
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _companyProfileService.DeleteAsync(id);
               
            if (!result.Success)
                return BadRequest(result.Message);

            var companyProfileResource = _mapper.Map<CompanyProfile, CompanyProfileResource>(result.Resource);
            return Ok(companyProfileResource);
        }
    }
}