using System.Threading.Tasks;

namespace jobagapi.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompletedAsync();
    }
}
