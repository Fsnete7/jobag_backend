using jobagapi.Domain.Models.JobOfferSystem;

namespace jobagapi.Domain.Services.Communication.JobOfferResponse
{
    public class SavePostulationResponse : BaseResponse<Postulation>
    {

        public SavePostulationResponse(Postulation resource) : base(resource)
        {
        }

        public SavePostulationResponse(string message = null) : base(message)
        {
        }
    }
}