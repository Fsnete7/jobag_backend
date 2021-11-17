using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.EmployerSystem;

namespace jobagapi.Domain.Repositories.EmployerRepositories
{
    public interface ICompanyProfileRepository
    {
        Task<IEnumerable<CompanyProfile>> ListAsync();
        
        Task AddAsync(CompanyProfile companyProfile);
        
        Task<CompanyProfile> FindByIdAsync(int id);

        void Delete(CompanyProfile companyProfile);
        
        
        void Update(CompanyProfile companyProfile);
    }
}