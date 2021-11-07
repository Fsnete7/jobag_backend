using System.Threading.Tasks;
using jobagapi.Domain.Models.SubscriptionSystem;

namespace jobagapi.Domain.Repositories.SubscriptionRepositories
{
    public interface IPaymentRepository
    {
        Task AddAsync(Payment payment);
        void Update(Payment payment);
        void Remove(Payment payment);
    }
}