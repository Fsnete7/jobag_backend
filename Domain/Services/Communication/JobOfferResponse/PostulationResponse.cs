using jobagapi.Domain.Models.JobOfferSystem;

namespace jobagapi.Domain.Services.Communication.JobOfferResponse
{
    public class PostulationResponse : BaseResponse<Postulation>
    {
        public PostulationResponse(Postulation resource) : base(resource)
        {
        }

        public PostulationResponse(string message) : base(message)
        {
        }
    }
}