using jobagapi.Domain.Models;
namespace jobagapi.Domain.Services.Communication.JobOffer
{
    public class SavePostulationResponse : BaseResponse
    {
        public Models.Postulation Postulation { get; private set; }
        public SavePostulationResponse(bool succes, string message, Models.Postulation postulation) : base(succes, message)
        {
            Postulation = postulation;
        }
        
        public SavePostulationResponse(Models.Postulation postulation) : this(true, string.Empty, postulation){}
        
        public SavePostulationResponse(string message) : this(false, message, null){}
    }
}