using jobagapi.Domain.Models;
namespace jobagapi.Domain.Services.Communication.JobOffer
{
    public class SaveContractResponse : BaseResponse
    {
        public Models.Contract Contract { get; private set; }
        public SaveContractResponse(bool succes, string message, Models.Contract contract) : base(succes, message)
        {
            Contract = contract;
        }
        
        public SaveContractResponse(Models.Contract contract) : this(true, string.Empty, contract){}
        
        public SaveContractResponse(string message) : this(false, message, null){}
    }
}