using jobagapi.Domain.Models.JobOfferSystem;

namespace jobagapi.Domain.Services.Communication.JobOfferResponse
{
    public class JobOfferResponse : BaseResponse<JobOffer>
    {
        public JobOfferResponse(JobOffer resource) : base(resource)
        {
        }

        public JobOfferResponse(string message) : base(message)
        {
        }
        
    }
}