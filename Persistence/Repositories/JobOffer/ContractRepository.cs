using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using jobagapi.Domain.Repositories;
using jobagapi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace jobagapi.Persistence.Repositories.JobOffer.JobOffer
{
    public class ContractRepository : BaseRepository, IContractRepository
    {
        public ContractRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Domain.Models.Contract>> ListAsync()
        {
            return await _context.Contracts.ToListAsync();
        }

        public async Task AddAsync(Domain.Models.Contract contract)
        {
            await _context.Contracts.AddAsync(contract);
        }

        public async Task<Domain.Models.Contract> FindByIdAsync(int id)
        {
            return await _context.Contracts.FindAsync(id);
        }
        
        public void update(Domain.Models.Contract contract)
        {
            _context.Contracts.Update(contract);
        }

        public void Delete(Domain.Models.Contract contract)
        {
            _context.Contracts.Remove(contract);
        }
    }
}