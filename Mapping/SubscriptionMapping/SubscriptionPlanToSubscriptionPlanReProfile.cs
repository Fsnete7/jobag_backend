using AutoMapper;
using jobagapi.Domain.Models.SubscriptionSystem;
using jobagapi.Resources.SubscriptionResources;

namespace jobagapi.Mapping.SubscriptionMapping
{
    public class SubscriptionPlanToSubscriptionPlanReProfile : Profile
    {
        public SubscriptionPlanToSubscriptionPlanReProfile()
        {
            CreateMap<SubscriptionPlan, SubscriptionPlanResource>();
        }
    }
}