// ==========================================================================================
//
// Copyright © 2023 HighFlowHub
//
// History
// ------------------------------------------------------------------------------------------
// Date         Author      
// ------------------------------------------------------------------------------------------
// 2023.10.23   Loan   
// ==========================================================================================
//
using System.Linq.Expressions;
using HighFlowHub.Entites;

/**
 * ========== DATABASE ACCESS QUERY AND UPDATE ==========
 */
namespace HighFlowHub.Repositories
{
    /// <summary>
    ///  Shared Repository
    /// </summary>
    /// <typeparam name="TEntity">Entity</typeparam>
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {private readonly DBContext _dBContext;

        /// <summary>
        ///  Constructor
        /// </summary>
        /// <param name="serviceProvider">Service Provider</param>
        /// <param name="dBContext">EF Core DbContext</param>
        public BaseRepository(DBContext dBContext)
        {
            _dBContext = dBContext;
        }

        /// <summary>
        ///  Get all items of Entity
        /// </summary>
        /// <returns>Item query</returns>
        public virtual async Task<IQueryable<TEntity>> GetAsync()
        {
            var context = _dBContext.Set<TEntity>();
            return await Task.Run(() => context);
        }

        /// <summary>
        ///  Get Item by Id
        /// </summary>
        /// <param name="id">Item Id</param>    
        /// <returns>Item of Entity</returns>
        public virtual async Task<IQueryable<TEntity>> GetItemByIdAsync (int id)
        {
            var listItems = await GetAsync();
            return listItems.Where(e => e.Id == id);
        }

        /// <summary>
        ///  Find entity 
        ///  </summary>
        /// <param name="predicate">Query condition</param>
        /// <returns>Found entity</returns>
        public virtual async Task<IQueryable<TEntity>> FindAsync (Expression<Func<TEntity, bool>> predicate)
        {
            var items = await GetAsync();
            return items.Where(predicate);
        }

        /// <summary>
        ///  Create entity
        /// </summary>
        /// <param name="item">new entity</param>
        /// <returns>New entity</returns>
        public virtual async Task<TEntity> CreateAsync(TEntity item)
        {
            var context = _dBContext.Set<TEntity>();

            var createItem = await context.AddAsync(item);
            await _dBContext.SaveChangesAsync();
            return createItem.Entity;
        } 

        /// <summary>
        ///  Update entity
        /// </summary>
        /// <param name="item">detect entity</param>
        /// <returns>updated entity</returns>
        public virtual async Task<TEntity> UpdateAsync (TEntity entity)
        {
            var updateItem = await FindAsync(e => e.Id.Equals(entity.Id));
            if (updateItem == null) return entity;
            
            _dBContext.Entry(updateItem).CurrentValues.SetValues(entity); // find then update detect field
            await _dBContext.SaveChangesAsync();
            return entity;
        }

        /// <summary>      
        ///  Delete Item
        /// </summary>
        /// <param name="Id">Delete Item Id</param>
        /// <returns>true if deleted</returns>
        public virtual async Task<bool> DeleteAsync (int Id)
        {   
            var detectedItem = await GetItemByIdAsync(Id);
            if (detectedItem == null) return false;
            
            _dBContext.Remove(detectedItem);
            
            return await _dBContext.SaveChangesAsync() > 0;
        }
    }
}