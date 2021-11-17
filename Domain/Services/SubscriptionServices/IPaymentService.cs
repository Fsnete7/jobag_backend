using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.SubscriptionSystem;
using jobagapi.Domain.Services.Communication.SubscriptionResponse;

namespace jobagapi.Domain.Services.SubscriptionServices
{
    public interface IPaymentService
    {
        //Get
        Task<IEnumerable<Payment>> ListAsync();
        //Post
        Task<SavePaymentResponse> SaveAsync(Payment payment);
        //UpdateOrModify
        Task<SavePaymentResponse> UpdateAsync(int id, Payment payment);
        //delete
        Task<PaymentResponse> DeleteAsync(int id);
    }
}