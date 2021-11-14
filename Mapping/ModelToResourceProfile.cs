using AutoMapper;
using jobagapi.Domain.Models;
using jobagapi.Domain.Models.JobOfferSystem;
using jobagapi.Resources;
using jobagapi.Resources.JobOfferResources;

namespace jobagapi.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<JobOffer, jobOfferResource>();
        }
    }
}