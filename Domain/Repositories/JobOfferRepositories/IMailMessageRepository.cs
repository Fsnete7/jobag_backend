using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.JobOfferSystem;

namespace jobagapi.Domain.Repositories.JobOfferRepositories
{
    public interface IMailMessageRepository
    {
        Task<IEnumerable<MailMessage>> ListAsync();
        
        Task AddAsync(MailMessage jobOffer);
        
        Task<MailMessage> FindByIdAsync(int id);

        void Delete(MailMessage mailMessage);
    }
}