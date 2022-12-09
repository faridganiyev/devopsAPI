using DevopsAPI.Data.Entities;
using DevopsAPI.Data.Specifications;

namespace DevopsAPI.Data.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns></returns>
        Task<IReadOnlyList<T>> GetAllAsync();

        /// <summary>
        /// Get all entities which matching specifications
        /// </summary>
        /// <param name="specifications"></param>
        /// <returns></returns>
        Task<IReadOnlyList<T>> GetListAsync(ISpecifications<T> specifications);

        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T?> GetByIdAsync(int id);

        /// <summary>
        /// Get entity which matching specifications
        /// </summary>
        /// <param name="specifications"></param>
        /// <returns></returns>
        Task<T?> GetBySpecifications(ISpecifications<T> specifications);

        /// <summary>
        /// Get count of entities with specifications
        /// </summary>
        /// <param name="specifications"></param>
        /// <returns></returns>
        Task<int> CountAsync(ISpecifications<T> specifications);

        /// <summary>
        /// Add new entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task AddAsync(T entity);

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);
    }
}
