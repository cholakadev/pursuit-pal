using Microsoft.EntityFrameworkCore;
using PursuitPal.Core.Repositories;
using PursuitPal.Infrastructure.Entities;
using System.Linq.Expressions;

namespace PursuitPal.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        protected PursuitPalDbContext _context;

        public Repository(PursuitPalDbContext context)
        {
            _context = context;
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<ICollection<TEntity>> AddManyAsync(ICollection<TEntity> entities)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities);
            await _context.SaveChangesAsync();
            return entities;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<int> DeleteAsync(TEntity entity, bool isHard = false)
        {
            if (entity is IActivatable activatable && !isHard)
            {
                activatable.Active = false;
                _context.Set<TEntity>().Update(entity);
            }
            else
            {
                _context.Set<TEntity>().Remove(entity);
            }

            return await SaveChangesAsync();
        }

        public virtual Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> match, bool tracking = false)
            => tracking
                ? _context.Set<TEntity>().SingleOrDefaultAsync(match)
                : _context.Set<TEntity>().AsNoTracking().SingleOrDefaultAsync(match);

        public virtual IQueryable<TEntity> GetAll(bool tracking = false)
            => tracking ? _context.Set<TEntity>() : _context.Set<TEntity>().AsNoTracking();

        public virtual async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
