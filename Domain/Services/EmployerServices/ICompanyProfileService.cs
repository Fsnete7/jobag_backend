using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.EmployerSystem;
using jobagapi.Domain.Services.Communication.CompanyProfileResponse;
using jobagapi.Domain.Services.Communication.EmployerResponse;

namespace jobagapi.Domain.Services.EmployerServices
{
    public interface ICompanyProfileService
    {
        
        Task<IEnumerable<CompanyProfile>> ListAsync();
        Task<SaveCompanyProfileResponse> SaveAsync(CompanyProfile companyProfile);

        Task<SaveCompanyProfileResponse> UpdateAsync(int id, CompanyProfile companyProfile);

        Task<CompanyProfileResponse> DeleteAsync(int id);
    }
}