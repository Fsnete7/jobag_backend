using jobagapi.Domain.Models;

namespace jobagapi.Domain.Services.Communication.JobOffer
{
    public class InterviewResponse : BaseResponse
    {
        public  Models.Interview Interview { get; set; }
        
        public InterviewResponse(bool succes, string message, Models.Interview interview) : base(succes, message)
        {
            Interview = interview;
        }
        
        public InterviewResponse(Models.Interview interview) : this(true, string.Empty, interview) {}
        public InterviewResponse(string message) : this(false,message, null) {}
    }
}