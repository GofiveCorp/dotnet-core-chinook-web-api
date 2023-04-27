using Microsoft.EntityFrameworkCore;
using MyChinook.Models;
using MyChinook.Repositories.IRepositories;
using System.Linq.Expressions;

namespace MyChinook.Repositories.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly MyChinookContext _db;
        internal DbSet<T> DbSet;
        public Repository(MyChinookContext dbContext)
        {
            _db = dbContext;    
            this.DbSet = _db.Set<T>();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = DbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                foreach(var prop in includeProperties.Split(new char[] {','},StringSplitOptions.RemoveEmptyEntries))
                query = query.Include(prop);
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter = null, bool tracked = true, string? includeProperties = null)
        {
            IQueryable<T> query = DbSet;
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                foreach (var prop in includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(prop);
                }
            }

            return await query.FirstOrDefaultAsync();

        }

        public async Task CreateAsync(T entity)
        {
            await _db.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task RemoveAsync(T entity)
        {
            _db.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task SaveAsync(T entity)
        {
            await _db.SaveChangesAsync();
        }
    }
}
