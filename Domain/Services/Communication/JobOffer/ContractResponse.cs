using jobagapi.Domain.Models;

namespace jobagapi.Domain.Services.Communication.JobOffer
{
    public class ContractResponse : BaseResponse
    {
        public  Models.Contract Contract { get; set; }
        
        public ContractResponse(bool succes, string message, Models.Contract contract) : base(succes, message)
        {
            Contract = contract;
        }
        
        public ContractResponse(Models.Contract contract) : this(true, string.Empty, contract) {}
        public ContractResponse(string message) : this(false,message, null) {}
    }
}