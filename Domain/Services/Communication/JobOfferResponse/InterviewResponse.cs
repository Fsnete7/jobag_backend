using jobagapi.Domain.Models.JobOfferSystem;

namespace jobagapi.Domain.Services.Communication.JobOfferResponse
{
    public class InterviewResponse : BaseResponse<Interview>
    {

        public InterviewResponse(Interview resource) : base(resource)
        {
        }

        public InterviewResponse(string message) : base(message)
        {
        }
    }
}