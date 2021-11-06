using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models;
using jobagapi.Domain.Services.Communication.JobOffer;

namespace jobagapi.Domain.Services
{
    public interface IMailiMessageService
    {
        Task<IEnumerable<MailMessage>> ListAsync();
        
        Task<SaveMailMessageResponse> SaveAsync(MailMessage mailMessage);
        
        Task<MailMessageResponse> DeletAsync(int id);

    }
}