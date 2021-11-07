using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models;

namespace jobagapi.Domain.Services
{
    public interface IMailiMessageService
    {
        Task<IEnumerable<MailMessage>> ListAsync();
    }
}