using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.SubscriptionSystem;
using jobagapi.Domain.Services.Communication.SubscriptionResponse;

namespace jobagapi.Domain.Services.SubscriptionServices
{
    public interface ISubscriptionPlanService
    {
        //Get
        Task<IEnumerable<SubscriptionPlan>> ListAsync();
        //Post
        Task<SaveSubscriptionPlanResponse> SaveAsync(SubscriptionPlan subscriptionPlan);
        //UpdateOrModify
        Task<SaveSubscriptionPlanResponse> UpdateAsync(int id, SubscriptionPlan subscriptionPlan);
        //delete
        Task<SubscriptionPlanResponse> DeleteAsync(int id);
    }
}