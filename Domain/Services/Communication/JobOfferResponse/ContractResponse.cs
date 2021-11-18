using jobagapi.Domain.Models.JobOfferSystem;

namespace jobagapi.Domain.Services.Communication.JobOfferResponse
{
    public class ContractResponse : BaseResponse<Contract>
    {

        public ContractResponse(Contract resource) : base(resource)
        {
        }

        public ContractResponse(string message) : base(message)
        {
        }
    }
}