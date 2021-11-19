using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.SubscriptionSystem;

namespace jobagapi.Domain.Repositories.SubscriptionRepositories
{
    public interface IPaymentRepository
    {
        //Get
        Task<IEnumerable<Payment>> ListAsync();
        //post
        Task AddAsync(Payment payment);
        //Update
        Task<Payment> FindByIdAsync(int id);
        void Update(Payment payment);
        //delete
        void Remove(Payment payment);
    }
}