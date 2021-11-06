
using jobagapi.Domain.Models;

namespace jobagapi.Domain.Services.Communication.JobOffer
{
    public class SaveJobOfferResponse : BaseResponse
    {
        
        public Models.JobOffer JobOffer { get; private set; }
        public SaveJobOfferResponse(bool succes, string message, Models.JobOffer jobOffer) : base(succes, message)
        {
            JobOffer = jobOffer;
        }
        
        public SaveJobOfferResponse(Models.JobOffer jobOffer) : this(true, string.Empty, jobOffer){}
        
        public SaveJobOfferResponse(string message) : this(false, message, null){}
        
    }
}