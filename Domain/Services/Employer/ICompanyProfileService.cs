using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models;

namespace jobagapi.Domain.Services.Employer
{
    public interface ICompanyProfileService
    {
        
        Task<IEnumerable<CompanyProfile>> ListAsync();
    }
}