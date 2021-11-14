using AutoMapper;
using jobagapi.Domain.Models;
using jobagapi.Domain.Models.JobOfferSystem;
using jobagapi.Resources;
using jobagapi.Resources.JobOfferResources;


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
