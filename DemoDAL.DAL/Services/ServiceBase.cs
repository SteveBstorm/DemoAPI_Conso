using ADOLibrary;
using DemoDAL.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoDAL.DAL.Services
{
    public abstract class ServiceBase<TKey, TEntity> : IService<TKey, TEntity>
        where TEntity : IEntity<TKey>
    {
        protected Connection Connection { get; private set; }

        public ServiceBase(Connection connection)
        {
            Connection = connection; 
        }

        public abstract TEntity Get(TKey key);
        public abstract IEnumerable<TEntity> GetAll();
        public abstract TKey Insert(TEntity entity);
        public abstract bool Update(TEntity entity);
        public abstract bool Delete(TKey key);
    }
}
