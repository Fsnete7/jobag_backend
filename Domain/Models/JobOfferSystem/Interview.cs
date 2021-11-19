using System;
<<<<<<< HEAD
using jobagapi.Domain.Models.PostulantSystem;

namespace jobagapi.Domain.Models.JobOfferSystem
{
    public class Interview
    {
=======
using jobagapi.Domain.Models.JobOfferSystem;

<<<<<<< HEAD:Resources/JobOfferResources/InterviewResource.cs
namespace jobagapi.Resources.JobOfferResources
=======
namespace jobagapi.Domain.Models.JobOfferSystem
>>>>>>> main:Domain/Models/JobOfferSystem/Interview.cs
{
    public class InterviewResource
    {
        
>>>>>>> main
        public int Id { get; set; }
        public string Link { get; set; }
        public double Duration { get; set; }
        public DateTime StartDate { get; set; }
        public bool Pending { get; set; }
        
<<<<<<< HEAD
        public JobOffer JobOffer { get; set; }
        public int JobOfferId { get; set; }
        
        public int PostulantId { get; set; }
        public Postulant Postulant { get; set; }
=======
        public int JobOfferId { get; set; }
        public int PostulantId { get; set; }

>>>>>>> main
    }
}