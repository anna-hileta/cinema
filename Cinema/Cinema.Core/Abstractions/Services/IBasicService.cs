using Cinema.Core.Entities;
using System.Collections.Generic;

namespace Cinema.Core.Abstractions.Services
{
    public interface IBasicService<TEntity, in TId> where TEntity : class, IEntity<TId>
    {
        public List<TEntity> Get();

        public TEntity GetById(TId id);

        public TEntity Add(TEntity entity);

        public TEntity Update(TEntity entity);

        public void Delete(TId id);
    }
}
