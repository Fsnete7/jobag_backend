using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models;
using jobagapi.Domain.Models.JobOfferSystem;

namespace jobagapi.Domain.Repositories
{
    public interface IContractRepository
    {
        Task<IEnumerable<Contract>> ListAsync();
        Task AddAsync(Contract contract);

        Task<Contract> FindByIdAsync(int id);

        void update(Contract contract);

        void Delete(Contract contract);
    }
}