using Microsoft.EntityFrameworkCore;
using StudentApp.Data;
using System.Linq.Expressions;

namespace StudentApp.Manager.Repo
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext dbContext;
        private readonly DbSet<T> dbSet;

        public Repository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }
        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await dbSet.Where(predicate).ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            var e = await dbSet.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return e.Entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var e = dbSet.Update(entity);
            await dbContext.SaveChangesAsync();
            return e.Entity; // No async version available in EF Core for Update, so marking the task as completed
        }

        public async Task DeleteAsync(T entity)
        {
            dbSet.Remove(entity);
            await dbContext.SaveChangesAsync();
            await Task.CompletedTask; // No async version available in EF Core for Remove, so marking the task as completed
        }
        public IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = dbSet;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query;
        }
    }
}
