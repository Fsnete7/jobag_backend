using jobagapi.Domain.Models.JobOfferSystem;

namespace jobagapi.Domain.Services.Communication.JobOfferResponse
{
    public class SaveContractResponse : BaseResponse<Contract>
    {

        public SaveContractResponse(Contract resource) : base(resource)
        {
        }

        public SaveContractResponse(string message = null) : base(message)
        {
        }

    }
}