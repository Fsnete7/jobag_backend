using jobagapi.Domain.Models.JobOfferSystem;

namespace jobagapi.Domain.Services.Communication.JobOfferResponse
{
    public class SaveInterviewResponse : BaseResponse<Interview>
    {

        public SaveInterviewResponse(Interview resource) : base(resource)
        {
        }

        public SaveInterviewResponse(string message = null) : base(message)
        {
        }
    }
}