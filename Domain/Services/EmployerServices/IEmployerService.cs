using System.Collections.Generic;
using System.Threading.Tasks;

namespace jobagapi.Domain.Services.EmployerServices
{
    public interface IEmployerService
    {
        
        Task<IEnumerable<Models.EmployerSystem.Employer>> ListAsync();
    }
}