using Core.DataAccess;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.Business
{
    public class BusinessBase<TEntity>
        where TEntity : class, IEntity, new()
    {
        IEntityRepository<TEntity> _entityRepository;

        public BusinessBase()
        {

        }
        public BusinessBase(IEntityRepository<TEntity> entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public virtual void Add(TEntity entity)
        {
            _entityRepository.Add(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            _entityRepository.Delete(entity);
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return _entityRepository.Get(filter);
        }

        public virtual List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return _entityRepository.GetAll(filter);
        }

        public virtual void Update(TEntity entity)
        {
            _entityRepository.Update(entity);
        }
    }
}