using System.Collections.Generic;
using System.Threading.Tasks;

namespace Indra.Infrastructure.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetByIdAsync(int id);
        public Task<T> InsertAsync(T entity);
        public Task<bool> RemoveByIdAsync(int id);
        public Task<T> UpdateAsync(T identity);

    }
}
