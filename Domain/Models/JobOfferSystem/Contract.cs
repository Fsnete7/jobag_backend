// Contract 2
namespace jobagapi.Domain.Models.JobOfferSystem
{
    public class Contract
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool Confirmation { get; set; }
        
        public JobOffer JobOffer { get; set; }
        public int JobOfferId { get; set; }
    }
}