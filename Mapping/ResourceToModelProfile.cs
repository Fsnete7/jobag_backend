using AutoMapper;
using jobagapi.Domain.Models;
using jobagapi.Resources;


namespace jobagapi.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveJobOfferResource, JobOffer>();
            CreateMap<SaveMailMessageResource, MailMessage>();
        }
    }
}
