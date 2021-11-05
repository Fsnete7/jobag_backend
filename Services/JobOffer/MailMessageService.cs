using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models;
using jobagapi.Domain.Repositories;
using jobagapi.Domain.Services;

namespace jobagapi.Services
{
    public class MailMessageService : IMailiMessageService
    {
        private readonly IMailMessageRepository _mailMessageRepository;

        public MailMessageService(IMailMessageRepository mailMessageRepository)
        {
            _mailMessageRepository = mailMessageRepository;
        }

        public async Task<IEnumerable<MailMessage>> ListAsync()
        {
            return await _mailMessageRepository.ListAsync();
        }
    }
}