using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.SubscriptionSystem;

namespace jobagapi.Domain.Repositories.SubscriptionRepositories
{
    public interface ISubscriptionPlanRepository
    {
        //Get
        Task<IEnumerable<SubscriptionPlan>> ListAsync();
        //post
        Task AddAsync(SubscriptionPlan subscriptionPlan);
        //Update
        Task<SubscriptionPlan> FindByIdAsync(int id);
        void Update(SubscriptionPlan subscriptionPlan);
        //delete
        void Remove(SubscriptionPlan subscriptionPlan);
    }
}