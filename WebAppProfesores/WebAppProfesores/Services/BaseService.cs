using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebAppProfesores.Model;
using WebAppProfesores.Model.Interfaces;


namespace WebAppProfesores.Services
{

    public abstract class BaseService<T>: IBaseService<T>  where T : BaseEntity
    {
        protected readonly StudentContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseService(StudentContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task CreateAsync(T entity)
        {
            _dbSet.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

    }
}
