using DemoDAL.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoDAL.DAL.Services
{
    public interface IService<TKey, TEntity>
        where TEntity : IEntity<TKey>
    {
        // Create
        TKey Insert(TEntity entity);

        // Read
        TEntity Get(TKey key);
        IEnumerable<TEntity> GetAll();

        // Update
        bool Update(TEntity entity);

        // Delete
        bool Delete(TKey key);
    
    }
}
