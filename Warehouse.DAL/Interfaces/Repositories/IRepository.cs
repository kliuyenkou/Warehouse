using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Warehouse.DAL.Interfaces.Repositories
{
    interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        void Add(TEntity entity);
        void Remove(TEntity entity);
    }
}
