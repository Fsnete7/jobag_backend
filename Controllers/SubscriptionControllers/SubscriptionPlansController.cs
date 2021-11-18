using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using jobagapi.Domain.Models.SubscriptionSystem;
using jobagapi.Domain.Services.SubscriptionServices;
using jobagapi.Extensions;
using jobagapi.Resources.SubscriptionResources;
using Microsoft.AspNetCore.Mvc;

namespace jobagapi.Controllers.SubscriptionControllers
{
    [Route("/api/v1/[controller]")]
    public class SubscriptionPlansController  : ControllerBase
    {
        private readonly ISubscriptionPlanService _subscriptionPlanService;
        private readonly IMapper _mapper;

        public SubscriptionPlansController(ISubscriptionPlanService subscriptionPlanService, IMapper mapper)
        {
            _subscriptionPlanService = subscriptionPlanService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<SubscriptionPlanResource>> GetAllList()
        {
            var subscriptionPlans = await _subscriptionPlanService.ListAsync();
            var resources = _mapper.Map<IEnumerable<SubscriptionPlan>, IEnumerable<SubscriptionPlanResource>>(subscriptionPlans);
            return resources;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveSubscriptionPlanResource resource) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var subscriptionPlans = _mapper.Map<SaveSubscriptionPlanResource, SubscriptionPlan>(resource);
            var result = await _subscriptionPlanService.SaveAsync(subscriptionPlans);

            if (!result.Success)
                return BadRequest(result.Message);

            var subscriptionPlanResource = _mapper.Map<SubscriptionPlan, SubscriptionPlanResource>(result.Resource);

            return Ok(subscriptionPlanResource);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveSubscriptionPlanResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
            
            var subscriptionPlan = _mapper.Map<SaveSubscriptionPlanResource, SubscriptionPlan>(resource);
            var result = await _subscriptionPlanService.UpdateAsync(id, subscriptionPlan);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var subscriptionPlanResource = _mapper.Map<SubscriptionPlan, SubscriptionPlanResource>(result.Resource);

            return Ok(subscriptionPlanResource);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _subscriptionPlanService.DeleteAsync(id);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var subscriptionPlanResource = _mapper.Map<SubscriptionPlan, SubscriptionPlanResource>(result.Resource);

            return Ok(subscriptionPlanResource);
        }
    }
}