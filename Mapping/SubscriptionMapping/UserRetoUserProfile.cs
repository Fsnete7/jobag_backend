using AutoMapper;
using jobagapi.Domain.Models.SubscriptionSystem;
using jobagapi.Resources.SubscriptionResources;

namespace jobagapi.Mapping.SubscriptionMapping
{
    public class UserRetoUserProfile : Profile
    {
        public UserRetoUserProfile()
        {
            CreateMap<SaveUserResource, User>();
        }
    }
}