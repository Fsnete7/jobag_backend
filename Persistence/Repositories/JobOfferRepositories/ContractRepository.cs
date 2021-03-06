using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.JobOfferSystem;
using jobagapi.Domain.Models.PostulantSystem;
using jobagapi.Domain.Repositories;
using jobagapi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace jobagapi.Persistence.Repositories.JobOfferPersistence
{
    public class ContractRepository : BaseRepository, IContractRepository
    {
        public ContractRepository(AppDbContext context) : base(context)
        {
        }
        public async Task AddAsync(Contract contract)
        {
            await _context.Contracts.AddAsync(contract);
        }
        public async Task<Contract> FindByIdAsync(int id)
        {
            return await _context.Contracts.FindAsync(id);
        }
        
        public void Update(Contract contract)
        {
            _context.Contracts.Update(contract);
        }
        
        public void Remove(Contract contract)
        {
            _context.Contracts.Remove(contract);
        }
        public async Task<IEnumerable<Contract>> ListAsync()
        {
            return await _context.Contracts.ToListAsync();
        }


    }
}