using jobagapi.Domain.Models;
namespace jobagapi.Domain.Services.Communication.JobOffer
{
    public class SaveInterviewResponse : BaseResponse
    {
        public Models.Interview Interview { get; private set; }
        public SaveInterviewResponse(bool succes, string message, Models.Interview interview) : base(succes, message)
        {
            Interview = interview;
        }
        
        public SaveInterviewResponse(Models.Interview interview) : this(true, string.Empty, interview){}
        
        public SaveInterviewResponse(string message) : this(false, message, null){}
    }
}