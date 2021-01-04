using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MusicController.Repository.GenericRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(long id);
        Task<IEnumerable<T>> GetAllAsync();
        
        Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> predicate);
        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate);
        
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        
        void UpdateEntity(T entity);
        
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
    }
}
