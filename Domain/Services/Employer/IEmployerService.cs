using System.Collections.Generic;
using System.Threading.Tasks;
namespace jobagapi.Domain.Services.Employer
{
    public interface IEmployerService
    {
        
        Task<IEnumerable<Models.Employer>> ListAsync();
    }
}