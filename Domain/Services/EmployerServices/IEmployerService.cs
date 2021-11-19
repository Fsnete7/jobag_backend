using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.EmployerSystem;
using jobagapi.Domain.Models.JobOfferSystem;
using jobagapi.Domain.Services.Communication.EmployerResponse;
using jobagapi.Resources.EmployerResources;

namespace jobagapi.Domain.Services.EmployerServices
{
    public interface IEmployerService
    {
        
        Task<IEnumerable<Employer>> ListAsync();
        Task<SaveEmployerResponse> SaveAsync(Employer employer);

        Task<SaveEmployerResponse> UpdateAsync(int id, Employer employer);

        Task<EmployerResponse> DeleteAsync(int id);
        
    }
}