using jobagapi.Domain.Models;

namespace jobagapi.Domain.Services.Communication.JobOffer
{
    public class PostulationResponse : BaseResponse
    {
        public  Models.Postulation Postulation { get; set; }
        
        public PostulationResponse(bool succes, string message, Models.Postulation postulation) : base(succes, message)
        {
            Postulation = postulation;
        }
        
        public PostulationResponse(Models.Postulation postulation) : this(true, string.Empty, postulation) {}
        public PostulationResponse(string message) : this(false,message, null) {}
    }
}