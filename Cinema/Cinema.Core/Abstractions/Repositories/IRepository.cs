using Cinema.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Cinema.Core.Abstractions.Repositories
{
    public interface IRepository<TEntity, in TId> where TEntity : class, IEntity<TId>
    {
        TEntity GetById(TId id);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        void AddMany(IEnumerable<TEntity> entities);

        void Delete(TEntity entity);
        void DeleteById(TId id);
        void DeleteMany(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        int Count();
    }
}
