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
        Task<EmployerResponse> SaveAsync(Employer employer);

        Task<EmployerResponse> UpdateAsync(int id, Employer employer);

        Task<EmployerResponse> DeletAsync(int id);
        
    }
}