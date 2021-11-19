using System;
using jobagapi.Domain.Models.JobOfferSystem;

<<<<<<< HEAD:Resources/JobOfferResources/InterviewResource.cs
namespace jobagapi.Resources.JobOfferResources
=======
namespace jobagapi.Domain.Models.JobOfferSystem
>>>>>>> main:Domain/Models/JobOfferSystem/Interview.cs
{
    public class InterviewResource
    {
        
        public int Id { get; set; }
        public string Link { get; set; }
        public double Duration { get; set; }
        public DateTime StartDate { get; set; }
        public bool Pending { get; set; }
        
        public int JobOfferId { get; set; }
        public int PostulantId { get; set; }

    }
}