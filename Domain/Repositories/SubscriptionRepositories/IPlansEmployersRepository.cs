using System.Threading.Tasks;
using jobagapi.Domain.Models.SubscriptionSystem;

namespace jobagapi.Domain.Repositories.SubscriptionRepositories
{
    public interface IPlansEmployersRepository
    {
        Task AddAsync(PlansEmployers plansE);
        void Update(PlansEmployers plansE);
        void Remove(PlansEmployers plansE);
    }
}