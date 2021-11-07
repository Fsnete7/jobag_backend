using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models;
using jobagapi.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace jobagapi.Controllers
{
    [Route("/api/v1/[controller]")]
    public class MailMessagesController : ControllerBase
    {
        private readonly IMailiMessageService _mailMessageService;

        public MailMessagesController(IMailiMessageService mailMessageService)
        {
            _mailMessageService = mailMessageService;
        }
        
        public async Task<IEnumerable<MailMessage>> GetAllAsync()
        {
            var mailMessages = await _mailMessageService.ListAsync();
            return mailMessages;
        }
    }
}