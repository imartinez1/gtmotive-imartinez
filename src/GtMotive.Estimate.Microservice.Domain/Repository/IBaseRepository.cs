using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace GtMotive.Estimate.Microservice.Domain.Repository
{
    /// <summary>
    /// IBaseRepository.
    /// </summary>
    /// <typeparam name="TEntity">TEntity.</typeparam>
    public interface IBaseRepository<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// Filtered.
        /// </summary>
        /// <param name="expression">expression.</param>
        /// <param name="cancellationToken">cancellationToken.</param>
        /// <returns>List TEntity .</returns>
        Task<List<TEntity>> Filtered(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken);

        /// <summary>
        /// GetOne.
        /// </summary>
        /// <param name="expression">expression.</param>
        /// <param name="cancellationToken">cancellationT   oken.</param>
        /// <returns>TEntity.</returns>
        Task<TEntity> GetOne(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken);

        /// <summary>
        /// Create.
        /// </summary>
        /// <param name="entity">entity.</param>
        /// <param name="cancellationToken">cancellationT   oken.</param>
        /// <returns>TEntity.</returns>
        Task<TEntity> Create(TEntity entity, CancellationToken cancellationToken);

        /// <summary>
        /// Update.
        /// </summary>
        /// <param name="entity">entity.</param>
        /// <param name="cancellationToken">cancellationT   oken.</param>
        /// <returns>TEntity.</returns>
        Task<TEntity> Update(TEntity entity, CancellationToken cancellationToken);

        /// <summary>
        /// Delete.
        /// </summary>
        /// <param name="entity">entity.</param>
        /// <param name="cancellationToken">cancellationT   oken.</param>
        /// <returns>TEntity.</returns>
        Task<bool> Delete(TEntity entity, CancellationToken cancellationToken);
    }
}
