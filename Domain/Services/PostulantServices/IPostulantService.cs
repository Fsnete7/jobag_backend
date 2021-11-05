using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.PostulantSystem;
using jobagapi.Domain.Services.Communication.PostulantResponse;

namespace jobagapi.Domain.Services.PostulantServices
{
    public interface IPostulantService
    {
        Task<PostulantResponse> GetByIdAsync(int id);
        Task<PostulantResponse> SaveAsync(Postulant postulant);
        Task<IEnumerable<Postulant>> ListAsync();
        Task<PostulantResponse> DeleteAsync(int id);
    }
}