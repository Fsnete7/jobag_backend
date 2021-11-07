using System.Threading.Tasks;
using jobagapi.Domain.Models.SubscriptionSystem;

namespace jobagapi.Domain.Repositories.SubscriptionRepositories
{
    public interface IPlansPostulantRepository
    {
        Task AddAsync(PlansPostulant plansP);
        void Update(PlansPostulant plansP);
        void Remove(PlansPostulant plansP);
    }
}