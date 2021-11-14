using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.JobOfferSystem;
using jobagapi.Domain.Repositories.JobOfferRepositories;
using jobagapi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace jobagapi.Persistence.Repositories.JobOfferPersistence
{
    public class MailMessageRepository : BaseRepository, IMailMessageRepository
    {
        public MailMessageRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<MailMessage>> ListAsync()
        {
            return await _context.MailMessages.ToListAsync();
        }

        public async Task AddAsync(MailMessage mailMessage)
        {
            await _context.MailMessages.AddAsync(mailMessage);        }

        public async Task<MailMessage> FindByIdAsync(int id)
        {
            return await _context.MailMessages.FindAsync(id);
        }


        public void Delete(MailMessage mailMessage)
        {
            _context.MailMessages.Remove(mailMessage);
        }
    }
}