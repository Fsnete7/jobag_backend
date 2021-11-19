using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.SubscriptionSystem;
using jobagapi.Domain.Repositories.SubscriptionRepositories;
using jobagapi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace jobagapi.Persistence.Repositories.SubscriptionPersistence
{
    public class PaymentRepository : BaseRepository, IPaymentRepository
    {
        public PaymentRepository(AppDbContext context) : base(context)
        {
        }
        //get
        public async Task<IEnumerable<Payment>> ListAsync()
        {
            return await _context.Payments.ToListAsync();
        }
        //post
        public async Task AddAsync(Payment payment)
        {
            await _context.AddAsync(payment);
        }
        //update
        public async Task<Payment> FindByIdAsync(int id)
        {
            return await _context.Payments.FindAsync(id);
        }
        public void Update(Payment payment)
        {
            _context.Update(payment);
        }
        //delete
        public void Remove(Payment payment)
        {
            _context.Remove(payment);
        }
    }
}