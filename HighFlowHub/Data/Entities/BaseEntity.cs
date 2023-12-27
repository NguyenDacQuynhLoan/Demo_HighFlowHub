// ==========================================================================================
//
// Copyright © 2023 HighFlowHub
//
// History
// ------------------------------------------------------------------------------------------
// Date         Author          EditDate    EditBy
// ------------------------------------------------------------------------------------------
// 2023.11.1   Loan            2023.11.1    Loan    
// ==========================================================================================
//

/**
 * ========== DATABASE INITIAL ==========
 */
namespace HighFlowHub.Entites
{
    /// <summary>
    ///  Shared Entity
    /// </summary>
    public class BaseEntity
    {
        public int Id { get; set; }
        
        /// <summary>
        ///  Mapping Entity to Model
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T MapTo<T>() where T : class, new()
        {
            var entity = new T();

            var entityProps = entity.GetType().GetProperties();
            var modelProps = this.GetType().GetProperties();
            foreach (var model in modelProps)
            {
                var detectEntity = entityProps.FirstOrDefault(e => e.Name == model.Name);
                if (detectEntity == null)
                {
                    continue;
                }
                detectEntity.SetValue(entity,model.GetValue(this));
            }
            return entity;
        }
    }
}