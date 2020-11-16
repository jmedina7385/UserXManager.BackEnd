using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity, bool update);
        void AddRange(IEnumerable<TEntity> entities);

        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);
    }
}