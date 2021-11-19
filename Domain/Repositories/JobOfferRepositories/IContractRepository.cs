using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models;
using jobagapi.Domain.Models.JobOfferSystem;
<<<<<<< HEAD:Domain/Repositories/JobOfferRepositories/IContractRepository.cs
using jobagapi.Domain.Models.PostulantSystem;
=======
>>>>>>> main:Domain/Repositories/JobOffer/IContractRepository.cs

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