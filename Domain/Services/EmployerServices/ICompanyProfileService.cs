using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.EmployerSystem;

namespace jobagapi.Domain.Services.EmployerServices
{
    public interface ICompanyProfileService
    {
        
        Task<IEnumerable<CompanyProfile>> ListAsync();
        Task<IEnumerable<CompanyProfile>> GetByIdAsync(int id);

    }
}