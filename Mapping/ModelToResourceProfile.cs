using AutoMapper;
using jobagapi.Domain.Models;
using jobagapi.Domain.Models.JobOfferSystem;
using jobagapi.Domain.Models.PostulantSystem;
using jobagapi.Domain.Models.SubscriptionSystem;
using jobagapi.Resources;
using jobagapi.Resources.JobOfferResources;
using jobagapi.Resources.PostulantResources;
using jobagapi.Resources.SubscriptionResources;


namespace jobagapi.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<SubscriptionPlan, SubscriptionPlanResource>();
            CreateMap<Payment, PaymentResource>();
            CreateMap<JobOffer, jobOfferResource>();
            CreateMap<Postulant, PostulantResource>();
            CreateMap<User, UserResource>();
            
            CreateMap<ProfessionalProfile, ProfessionalProfileResource>();
            CreateMap<Language, LanguageResource>();
            CreateMap<Skill, SkillResource>();
            CreateMap<Degree, DegreeResource>();
        }
    }
}