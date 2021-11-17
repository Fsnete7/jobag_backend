namespace jobagapi.Domain.Services.Communication.JobOfferResponse
{
    public class JobOfferResponse : BaseResponse<Models.JobOfferSystem.JobOffer>
    {
        public JobOfferResponse(string message) : base(message) { }

        public JobOfferResponse(Models.JobOfferSystem.JobOffer jobOffer) : base(jobOffer) { }
    }
}