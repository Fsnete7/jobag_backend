namespace jobagapi.Domain.Services.Communication.JobOffer
{
    public class JobOfferResponse : BaseResponse
    {
        public Models.JobOffer JobOffer { get; set; }
        public JobOfferResponse(bool succes, string message, Models.JobOffer jobOffer) : base(succes, message)
        {
            JobOffer = jobOffer;
        }

        public JobOfferResponse(Models.JobOffer jobOffer) : this(true, string.Empty, jobOffer) {}
        
        public JobOfferResponse(string message) : this(false, message, null) {}
    }
}