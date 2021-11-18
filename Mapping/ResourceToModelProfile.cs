using System.Net.Mail;
using AutoMapper;
using jobagapi.Domain.Models;
using jobagapi.Domain.Models.EmployerSystem;
using jobagapi.Domain.Models.JobOfferSystem;
using jobagapi.Domain.Models.PostulantSystem;
using jobagapi.Domain.Models.SubscriptionSystem;
using jobagapi.Resources;
using jobagapi.Resources.EmployerResources;
using jobagapi.Resources.JobOfferResources;
using jobagapi.Resources.PostulantResources;
using jobagapi.Resources.SubscriptionResources;


namespace jobagapi.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            //--------------- Scoped Postulant Bounded Context ---------------
            CreateMap<SaveJobOfferResource, JobOffer>();
            CreateMap<SavePostulantResource, Postulant>();
            CreateMap<SaveDegreeResource, Degree>();
            CreateMap<SaveLanguageResource, Language>();
            CreateMap<SaveSkillResource, Skill>();
            CreateMap<SaveProfessionalProfileResource, ProfessionalProfile>();
            CreateMap<SaveEmployerResource, Employer>();
            
            //--------------- Scoped Subscription Bounded Context ---------------
            CreateMap<SavePaymentResource, Payment>();
            CreateMap<SaveSubscriptionPlanResource, SubscriptionPlan>();
            CreateMap<SaveUserResource, User>();
        }
    }
}
