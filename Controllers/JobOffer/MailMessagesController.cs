using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using jobagapi.Extensions;
using jobagapi.Domain.Models;
using jobagapi.Domain.Services;
using jobagapi.Resources;
using Microsoft.AspNetCore.Mvc;

namespace jobagapi.Controllers
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

            if (!result.Succes)
                return BadRequest(result.Message);

            var mailMessageResource = _mapper.Map<MailMessage, SaveMailMessageResource>(result.MailMessage);
            return Ok(mailMessageResource);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _mailMessageService.DeletAsync(id);
               
            if (!result.Succes)
                return BadRequest(result.Message);

            var mailMessageResource = _mapper.Map<MailMessage, SaveMailMessageResource>(result.MailMessage);
            return Ok(mailMessageResource);
        }
    }
}