using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using jobagapi.Domain.Models.JobOfferSystem;
using jobagapi.Domain.Services;
using jobagapi.Extensions;
using jobagapi.Resources;
using jobagapi.Resources.JobOfferResources;
using Microsoft.AspNetCore.Mvc;

namespace jobagapi.Controllers.JobOfferControllers
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
        public async Task<IEnumerable<ContractResource>> GetAllAsync()
        {
            var contracts = await _contractService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Contract>, IEnumerable<ContractResource>>(contracts);
            return resources;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] SaveContractResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var contract = _mapper.Map<SaveContractResource, Contract>(resource);
            var result = await _contractService.SaveAsync(contract);

            if (!result.Success)
                return BadRequest(result.Message);

<<<<<<< HEAD:Controllers/JobOfferControllers/ContractsController.cs
            var contractResource = _mapper.Map<Contract, ContractResource>(result.Resource);
=======
            var contractResource = _mapper.Map<Contract, SaveContractResource>(result.Resource);
>>>>>>> main:Controllers/JobOffer/ContractsController.cs
            return Ok(contractResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveContractResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var contract = _mapper.Map<SaveContractResource, Contract>(resource);
            var result = await _contractService.UpdateAsync(id, contract);
            
            if (!result.Success)
                return BadRequest(result.Message);

<<<<<<< HEAD:Controllers/JobOfferControllers/ContractsController.cs
            var jobOfferResource = _mapper.Map<Contract, ContractResource>(result.Resource);
=======
            var jobOfferResource = _mapper.Map<Contract, SaveContractResource>(result.Resource);
>>>>>>> main:Controllers/JobOffer/ContractsController.cs
            return Ok(jobOfferResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _contractService.DeleteAsync(id);
               
            if (!result.Success)
                return BadRequest(result.Message);

<<<<<<< HEAD:Controllers/JobOfferControllers/ContractsController.cs
            var contractResource = _mapper.Map<Contract, ContractResource>(result.Resource);
=======
            var contractResource = _mapper.Map<Contract, SaveContractResource>(result.Resource);
>>>>>>> main:Controllers/JobOffer/ContractsController.cs
            return Ok(contractResource);
        }
    }
}