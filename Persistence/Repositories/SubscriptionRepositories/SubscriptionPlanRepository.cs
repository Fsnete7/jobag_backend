using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.SubscriptionSystem;
using jobagapi.Domain.Repositories.SubscriptionRepositories;
using jobagapi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace jobagapi.Persistence.Repositories.SubscriptionRepositories
{
    public class SubscriptionPlanRepository : BaseRepository, ISubscriptionPlanRepository
    {
        public SubscriptionPlanRepository(AppDbContext context) : base(context)
        {
        }
        //get
        public async Task<IEnumerable<SubscriptionPlan>> ListAsync()
        {
            return await _context.SubscriptionPlans.ToListAsync();
        }
        //post
        public async Task AddAsync(SubscriptionPlan subscriptionPlan)
        {
            await _context.AddAsync(subscriptionPlan);
        }
        //update
        public async Task<SubscriptionPlan> FindByIdAsync(int id)
        {
            return await _context.SubscriptionPlans.FindAsync(id);
        }
        public void Update(SubscriptionPlan subscriptionPlan)
        {
            _context.Update(subscriptionPlan);
        }
        //delete
        public void Remove(SubscriptionPlan subscriptionPlan)
        {
            _context.Remove(subscriptionPlan);
        }
    }
}