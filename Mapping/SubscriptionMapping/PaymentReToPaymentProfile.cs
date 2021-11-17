using AutoMapper;
using jobagapi.Domain.Models.SubscriptionSystem;
using jobagapi.Resources.SubscriptionResources;

namespace jobagapi.Mapping.SubscriptionMapping
{
    public class PaymentReToPaymentProfile : Profile
    {
        public PaymentReToPaymentProfile()
        {
            CreateMap<SavePaymentResource, Payment>();
        }
    }
}