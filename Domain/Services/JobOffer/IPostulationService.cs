using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models;
using jobagapi.Domain.Services.Communication.JobOffer;

namespace jobagapi.Domain.Services
{
    public interface IPostulationService
    {
        Task<IEnumerable<Postulation>> ListAsync();

        Task<SavePostulationResponse> SaveAsync(Postulation postulation);

        Task<SavePostulationResponse> UpdateAsync(int id, Postulation postulation);

        Task<PostulationResponse> DeletAsync(int id);  
    }
}