﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using jobagapi.Domain.Models.SubscriptionSystem;
using jobagapi.Domain.Services.SubscriptionServices;
using jobagapi.Extensions;
using jobagapi.Resources.SubscriptionResources;


namespace jobagapi.Controllers.SubscriptionControllers
{
    [Route("/api/v1/[controller]")]
    public class PaymentsController : ControllerBase
    {
       private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;

        public PaymentsController(IPaymentService paymentService, IMapper mapper)
        {
            _paymentService = paymentService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IEnumerable<PaymentResource>> GetAllList()
        {
            var payments = await _paymentService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Payment>, IEnumerable<PaymentResource>>(payments);
            return resources;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SavePaymentResource resource) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var payments = _mapper.Map<SavePaymentResource, Payment>(resource);
            var result = await _paymentService.SaveAsync(payments);

            if (!result.Success)
                return BadRequest(result.Message);

            var paymentResource = _mapper.Map<Payment, PaymentResource>(result.Resource);

            return Ok(paymentResource);
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SavePaymentResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }
            
            var payment = _mapper.Map<SavePaymentResource, Payment>(resource);
            var result = await _paymentService.UpdateAsync(id, payment);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var paymentResource = _mapper.Map<Payment, PaymentResource>(result.Resource);

            return Ok(paymentResource);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _paymentService.DeleteAsync(id);
            
            if (!result.Success)
                return BadRequest(result.Message);

            var paymentResource = _mapper.Map<Payment, PaymentResource>(result.Resource);

            return Ok(paymentResource);
        }
    }
}