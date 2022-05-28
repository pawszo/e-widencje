using e_widencje.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace e_widencje.Repositories
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
    }
}
