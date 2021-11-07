using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using jobagapi.Domain.Models;
using jobagapi.Domain.Repositories;
using jobagapi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace jobagapi.Persistence.Repositories.JobOffer.JobOffer
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