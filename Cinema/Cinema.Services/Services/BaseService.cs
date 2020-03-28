using AutoMapper;
using Cinema.Core.Abstractions;
using Cinema.Core.Abstractions.Repositories;
using Cinema.Core.Abstractions.Services;
using Cinema.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cinema.Services.Services
{
    public class BaseService<TEntity, TId> : IBasicService<TEntity, TId> where TEntity : class, IEntity<TId>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<TEntity, TId> repository;
        private readonly IMapper mapper;

        public BaseService(IUnitOfWork unitOfWork, IRepository<TEntity, TId> repository,  IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.mapper = mapper;
        }

        public List<TEntity> Get()
        {
            var entities = repository.GetAll();
            return entities.ToList();
        }

        public TEntity GetById(TId id)
        {
            TEntity entity = repository.GetById(id);

            if (entity == null)
            {
                throw new ArgumentException( $"Couldnt find entity with Id - {id}");
            }

            return entity;
        }

        public TEntity Add(TEntity entity)
        {
            repository.Add(entity);
            unitOfWork.SaveChanges();

            return entity;
        }

        protected virtual void UpdateProperties(TEntity from, TEntity to)
        {
            mapper.Map <TEntity, TEntity>(from, to);
        }

        public TEntity Update(TEntity entity)
        {
            var existingEntity = repository.GetById(entity.Id);
            if (existingEntity == null)
                throw new ArgumentException($"Couldnt find entity with Id - {entity.Id}");

            UpdateProperties(entity, existingEntity);

            repository.Update(existingEntity);
            unitOfWork.SaveChanges();

            return repository.GetById(entity.Id);
        }

        public void Delete(TId id)
        {
            repository.DeleteById(id);
            unitOfWork.SaveChanges();
        }
    }
}



