using Microsoft.EntityFrameworkCore;
using MusicController.Entites.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MusicController.Repository.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        // Instance of the DbContext. Must be passed or injected.        
        private readonly MusicDBContext _context;
        private readonly DbSet<T> _entities;

        public GenericRepository(MusicDBContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }
        public async Task<T> GetAsync(long id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return await _entities.SingleOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _entities.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> predicate)
        {
            return await _entities.Where(predicate).ToListAsync();
        }


        public async Task AddAsync(T entity)
        {
            await _entities.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _entities.AddRangeAsync(entities);
        }

        public void Remove(T entity)
        {
            _entities.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _entities.RemoveRange(entities);
        }
        public void UpdateEntity(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await _entities.AnyAsync(predicate);
        }

    }
}
