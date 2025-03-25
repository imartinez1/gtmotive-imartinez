using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Repository;
using GtMotive.Estimate.Microservice.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GtMotive.Estimate.Microservice.Infrastructure.Repository
{
    public class BaseRepository<TEntity>(ApplicationDbContext context) : IBaseRepository<TEntity>
        where TEntity : class
    {
        private readonly ApplicationDbContext _context = context;

        public virtual async Task<TEntity> Create(TEntity entity, CancellationToken cancellationToken)
        {
            var createdEntity = _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();
            return createdEntity.Entity;
        }

        public virtual async Task<bool> Delete(TEntity entity, CancellationToken cancellationToken)
        {
            _context.Set<TEntity>().Remove(entity);
            return (await _context.SaveChangesAsync(cancellationToken)) > 0;
        }

        public virtual async Task<List<TEntity>> Filtered(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken)
        {
            return await _context.Set<TEntity>().AsNoTracking().Where(expression).ToListAsync(cancellationToken);
        }

        public virtual async Task<TEntity> GetOne(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken)
        {
            return await _context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(expression, cancellationToken);
        }

        public virtual async Task<TEntity> Update(TEntity entity, CancellationToken cancellationToken)
        {
            var modifyEntity = _context.Update(entity);
            await _context.SaveChangesAsync(cancellationToken);
            _context.ChangeTracker.Clear();

            return modifyEntity.Entity;
        }
    }
}
