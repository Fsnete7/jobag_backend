using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.JobOfferSystem;
using jobagapi.Domain.Services.Communication.JobOfferResponse;

namespace jobagapi.Domain.Services.JobOfferServices
{
    public interface IMailiMessageService
    {
        Task<IEnumerable<MailMessage>> ListAsync();
        
        Task<MailMessageResponse> SaveAsync(MailMessage mailMessage);
        
        Task<MailMessageResponse> DeleteAsync(int id);

    }
}