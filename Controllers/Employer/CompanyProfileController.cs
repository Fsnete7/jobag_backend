using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models;
using jobagapi.Domain.Services;
using jobagapi.Domain.Services.Employer;
using Microsoft.AspNetCore.Mvc;

namespace jobagapi.Controllers.Employer
{  [Route("/api/v1/[controller]")]

    public class CompanyProfileController : Controller
    {
        private readonly ICompanyProfileService _companyProfileService;
        
        public CompanyProfileController(ICompanyProfileService companyProfileService)
        {
            _companyProfileService = companyProfileService;
        }
        
        public async Task<IEnumerable<CompanyProfile>> GetAllAsync()
        {
            var companyProfiles = await _companyProfileService.ListAsync();
            return companyProfiles;
        }
        
      
    }
}