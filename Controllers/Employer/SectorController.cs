using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models;
using jobagapi.Domain.Services.Employer;
using Microsoft.AspNetCore.Mvc;

namespace jobagapi.Controllers.Employer
{ [Route("/api/v1/[controller]")]
    public class SectorController : Controller
    {
        private readonly ISectorService _sectorService;
        
        public SectorController(ISectorService sectorService)
        {
            _sectorService = sectorService;
        }
        
        public async Task<IEnumerable<Sector>> GetAllAsync()
        {
            var sectors = await _sectorService.ListAsync();
            return sectors;
        }
    }
}