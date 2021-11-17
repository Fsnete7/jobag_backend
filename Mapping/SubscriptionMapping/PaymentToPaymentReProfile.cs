using AutoMapper;
using jobagapi.Domain.Models.SubscriptionSystem;
using jobagapi.Resources.SubscriptionResources;

namespace jobagapi.Mapping.SubscriptionMapping
{
    public class PaymentToPaymentReProfile : Profile
    {
        public PaymentToPaymentReProfile()
        {
            CreateMap<Payment, PaymentResource>();
        }
    }
}