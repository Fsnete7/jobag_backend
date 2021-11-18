using AutoMapper;
using jobagapi.Domain.Models.SubscriptionSystem;
using jobagapi.Resources.SubscriptionResources;

namespace jobagapi.Mapping.SubscriptionMapping
{
    public class UserToUserReProfile : Profile
    {
        public UserToUserReProfile()
        {
            CreateMap<User, UserResource>();
        }
    }
}