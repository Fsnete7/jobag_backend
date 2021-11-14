using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using jobagapi.Domain.Models.JobOfferSystem;
using jobagapi.Domain.Services.JobOfferServices;
using jobagapi.Extensions;
using jobagapi.Resources.JobOfferResources;
using Microsoft.AspNetCore.Mvc;

namespace jobagapi.Controllers.JobOfferControllers
{
    [Route("/api/v1/[controller]")]
    public class MailMessagesController : ControllerBase
    {
        private readonly IMailiMessageService _mailMessageService;
        private readonly IMapper _mapper;
        
        public MailMessagesController(IMailiMessageService mailMessageService, IMapper mapper)
        {
            _mailMessageService = mailMessageService;
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<MailMessage>> GetAllAsync()
        {
            var mailMessages = await _mailMessageService.ListAsync();
            return mailMessages;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] SaveMailMessageResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var mailMessage = _mapper.Map<SaveMailMessageResource, MailMessage>(resource);
            var result = await _mailMessageService.SaveAsync(mailMessage);

            if (!result.Success)
                return BadRequest(result.Message);

            var mailMessageResource = _mapper.Map<MailMessage, SaveMailMessageResource>(result.Resource);
            return Ok(mailMessageResource);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _mailMessageService.DeleteAsync(id);
               
            if (!result.Success)
                return BadRequest(result.Message);

            var mailMessageResource = _mapper.Map<MailMessage, SaveMailMessageResource>(result.Resource);
            return Ok(mailMessageResource);
        }
    }
}