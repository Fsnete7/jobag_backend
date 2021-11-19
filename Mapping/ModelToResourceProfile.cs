using AutoMapper;
using jobagapi.Domain.Models.EmployerSystem;
using jobagapi.Domain.Models.JobOfferSystem;
using jobagapi.Domain.Models.PostulantSystem;
using jobagapi.Domain.Models.SubscriptionSystem;
using jobagapi.Resources.EmployerResources;
using jobagapi.Resources.JobOfferResources;
using jobagapi.Resources.PostulantResources;
using jobagapi.Resources.SubscriptionResources;


namespace jobagapi.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {

            //--------------- Scoped Postulant Bounded Context ---------------
            CreateMap<JobOffer, jobOfferResource>();
            CreateMap<Postulant, PostulantResource>();
            CreateMap<ProfessionalProfile, ProfessionalProfileResource>();
            CreateMap<Language, LanguageResource>();
            CreateMap<Skill, SkillResource>();
            CreateMap<Degree, DegreeResource>();

<<<<<<< HEAD
            
            CreateMap<Postulation, PostulationResource>();
            CreateMap<Interview, InterviewResource>();
            CreateMap<Contract, ContractResource>();
            
=======
>>>>>>> main
            //--------------- Scoped Employer Bounded Context ---------------
            CreateMap<Employer, EmployerResource>();
            CreateMap<CompanyProfile, CompanyProfileResource>();
            CreateMap<Sector, SectorResource>();
            
            //--------------- Scoped Subscription Bounded Context ---------------
            CreateMap<Payment, PaymentResource>();
            CreateMap<SubscriptionPlan, SubscriptionPlanResource>();
            CreateMap<User, UserResource>();
        }
    }
}