using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models;

namespace jobagapi.Domain.Repositories
{
    public interface IMailMessageRepository
    {
        Task<IEnumerable<MailMessage>> ListAsync();
        
        Task AddAsync(MailMessage jobOffer);
        
        Task<MailMessage> FindByIdAsync(int id);

        void Delete(MailMessage mailMessage);
    }
}