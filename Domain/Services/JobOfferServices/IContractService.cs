using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models;
using jobagapi.Domain.Models.JobOfferSystem;
using jobagapi.Domain.Services.Communication.JobOfferResponse;

namespace jobagapi.Domain.Services
{
    public interface IContractService
    {
        Task<IEnumerable<Contract>> ListAsync();

        Task<SaveContractResponse> SaveAsync(Contract contract);

        Task<SaveContractResponse> UpdateAsync(int id, Contract contract);

        Task<ContractResponse> DeletAsync(int id);  
    }
}