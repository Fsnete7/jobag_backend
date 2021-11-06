using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models;
using jobagapi.Domain.Services.Employer;
using Microsoft.AspNetCore.Mvc;

namespace jobagapi.Controllers.Employer
{ [Route("/api/v1/[controller]")]
    public class EmployerController : Controller
    {
        private readonly IEmployerService _employerService;
        
        public EmployerController(IEmployerService employerService)
        {
            _employerService = employerService;
        }
        
        public async Task<IEnumerable<Domain.Models.Employer>> GetAllAsync()
        {
            var employers = await _employerService.ListAsync();
            return employers;
        }
    }
}