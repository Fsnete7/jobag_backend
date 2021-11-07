using System.Collections.Generic;
using System.Threading.Tasks;
using jobagapi.Domain.Models.PostulantSystem;

namespace jobagapi.Domain.Repositories.PostulantRepositories
{
    public interface IPostulantRepository
    {
        Task<IEnumerable<Postulant>> ListAsync();
        Task<Postulant> FindById(int id);
        void Update(Postulant postulant);
        void Remove(Postulant postulant);
        Task<IEnumerable<Postulant>> FindPostulantByName(string name);
    }
}