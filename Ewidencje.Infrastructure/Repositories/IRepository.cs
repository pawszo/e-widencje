using Ewidencje.Domain.Models;

namespace Ewidencje.Infrastructure.Repositories
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Add(T entity);
        Task<T> Update(int id, T entity);
        Task<T> Delete(int id);
    }
}
