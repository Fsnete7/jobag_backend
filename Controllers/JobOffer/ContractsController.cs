using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using jobagapi.Domain.Models;
using jobagapi.Domain.Services;
using jobagapi.Domain.Services.Communication.JobOffer;
using jobagapi.Extensions;
using jobagapi.Resources;
using Microsoft.AspNetCore.Mvc;

namespace jobagapi.Controllers
{
    [Route("/api/v1/[controller]")]
    public class ContractsController : ControllerBase
    {
        private readonly IContractService _contractService;
        private readonly IMapper _mapper;

        public ContractsController(IContractService contractService, IMapper mapper)
        {
            _contractService = contractService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<contractResource>> GetAllAsync()
        {
            var contracts = await _contractService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Contract>, IEnumerable<contractResource>>(contracts);
            return resources;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] SaveContractResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var contract = _mapper.Map<SaveContractResource, Contract>(resource);
            var result = await _contractService.SaveAsync(contract);

            if (!result.Succes)
                return BadRequest(result.Message);

            var contractResource = _mapper.Map<Contract, SaveContractResource>(result.Contract);
            return Ok(contractResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveContractResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var contract = _mapper.Map<SaveContractResource, Contract>(resource);
            var result = await _contractService.UpdateAsync(id, contract);
            
            if (!result.Succes)
                return BadRequest(result.Message);

            var jobOfferResource = _mapper.Map<Contract, SaveContractResource>(result.Contract);
            return Ok(jobOfferResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _contractService.DeletAsync(id);
               
            if (!result.Succes)
                return BadRequest(result.Message);

            var contractResource = _mapper.Map<Contract, SaveContractResource>(result.Contract);
            return Ok(contractResource);
        }
    }
}