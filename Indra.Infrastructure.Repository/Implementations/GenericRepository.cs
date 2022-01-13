using Indra.Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CapgeminiDDD.Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly IUnitOfWork _unitOfWork;

        public GenericRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public virtual async Task<System.Collections.Generic.IEnumerable<T>> GetAllAsync()
        {
            return await _unitOfWork.Context.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _unitOfWork.Context.Set<T>().FindAsync(id);
        }

        public virtual async Task<T> InsertAsync(T entity)
        {
            await _unitOfWork.Context.AddAsync(entity);
            return entity;
        }

        public virtual async Task<bool> RemoveByIdAsync(int id)
        {
            var dbEntity = await _unitOfWork.Context.Set<T>().FindAsync(id);
            if (dbEntity != null)
            {
                _unitOfWork.Context.Set<T>().Remove(dbEntity);
                return true;
            }
            return false;
        }

        public virtual Task<T> UpdateAsync(T identity)
        {
            throw new System.NotImplementedException();
        }
    }
}
