using System.Net.Mail;
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
    public class ResourceToModelProfile : Profile
    {
<<<<<<< HEAD
        public ResourceToModelProfile()
        {
            CreateMap<SaveJobOfferResource, JobOffer>();
            CreateMap<SaveMailMessageResource, MailMessage>();
            CreateMap<SavePostulantResource, Postulant>();
            CreateMap<SaveDegreeResource, Degree>();
            CreateMap<SaveLanguageResource, Language>();
            CreateMap<SaveSkillResource, Skill>();
            CreateMap<SaveProfessionalProfileResource, ProfessionalProfile>();
            CreateMap<SavePaymentResource, Payment>();
            CreateMap<SaveSubscriptionPlanResource, SubscriptionPlan>();
            CreateMap<SaveUserResource, User>();
        }
=======
        //delete file
>>>>>>> main
    }
}
