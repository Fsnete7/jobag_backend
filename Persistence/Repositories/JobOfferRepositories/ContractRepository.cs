using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.JobOfferSystem;
<<<<<<< HEAD:Persistence/Repositories/JobOfferRepositories/ContractRepository.cs
using jobagapi.Domain.Models.PostulantSystem;
=======
>>>>>>> main:Persistence/Repositories/JobOffer/ContractRepository.cs
using jobagapi.Domain.Repositories;
using jobagapi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

<<<<<<< HEAD:Persistence/Repositories/JobOfferRepositories/ContractRepository.cs
namespace jobagapi.Persistence.Repositories.JobOfferPersistence
=======
namespace jobagapi.Persistence.Repositories.JobOfferRepositories
>>>>>>> main:Persistence/Repositories/JobOffer/ContractRepository.cs
{
    public class ContractRepository : BaseRepository, IContractRepository
    {
        public ContractRepository(AppDbContext context) : base(context)
        {
        }
<<<<<<< HEAD:Persistence/Repositories/JobOfferRepositories/ContractRepository.cs
=======

        public async Task<IEnumerable<Contract>> ListAsync()
        {
            return await _context.Contracts.ToListAsync();
        }

>>>>>>> main:Persistence/Repositories/JobOffer/ContractRepository.cs
        public async Task AddAsync(Contract contract)
        {
            await _context.Contracts.AddAsync(contract);
        }
<<<<<<< HEAD:Persistence/Repositories/JobOfferRepositories/ContractRepository.cs
=======

>>>>>>> main:Persistence/Repositories/JobOffer/ContractRepository.cs
        public async Task<Contract> FindByIdAsync(int id)
        {
            return await _context.Contracts.FindAsync(id);
        }
        
<<<<<<< HEAD:Persistence/Repositories/JobOfferRepositories/ContractRepository.cs
        public void Update(Contract contract)
        {
            _context.Contracts.Update(contract);
        }
        
        public void Remove(Contract contract)
=======
        public void update(Contract contract)
        {
            _context.Contracts.Update(contract);
        }

        public void Delete(Contract contract)
>>>>>>> main:Persistence/Repositories/JobOffer/ContractRepository.cs
        {
            _context.Contracts.Remove(contract);
        }
        public async Task<IEnumerable<Contract>> ListAsync()
        {
            return await _context.Contracts.ToListAsync();
        }


    }
}