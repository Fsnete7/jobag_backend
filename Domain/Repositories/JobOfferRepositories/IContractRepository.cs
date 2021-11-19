using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models;
using jobagapi.Domain.Models.JobOfferSystem;
using jobagapi.Domain.Models.PostulantSystem;

namespace jobagapi.Domain.Repositories
{
    public interface IContractRepository
    {
        Task<IEnumerable<Contract>> ListAsync();
        Task AddAsync(Contract contract);
        void Update(Contract contract);
        void Remove(Contract contract);
        Task<Contract> FindByIdAsync(int id);
    }
}