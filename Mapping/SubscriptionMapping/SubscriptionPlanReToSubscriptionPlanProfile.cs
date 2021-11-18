using AutoMapper;
using jobagapi.Domain.Models.SubscriptionSystem;
using jobagapi.Resources.SubscriptionResources;

namespace jobagapi.Mapping.SubscriptionMapping
{
    public class SubscriptionPlanReToSubscriptionPlanProfile : Profile
    {
        public SubscriptionPlanReToSubscriptionPlanProfile()
        {
            CreateMap<SaveSubscriptionPlanResource, SaveSubscriptionPlanResource>();
        }
    }
}