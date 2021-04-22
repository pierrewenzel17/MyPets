using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace MyPetsAPI.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            this.Context = context;
        }

        public TEntity Get(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public TEntity Add(TEntity entity)
        {
            return Context.Set<TEntity>().Add(entity).Entity;
        }

        public TEntity Update(int id, TEntity newEntity)
        {
            var entity = Get(id);
            if (entity is not null)
                Context.Entry(entity).CurrentValues.SetValues(newEntity);
            else
                throw new ArgumentException("This object is not exist in database");
            return entity;
        }

        public void Remove(int id)
        {
            var entity = Get(id);
            if (entity is not null)
                Context.Set<TEntity>().Remove(entity);
            else
                throw new ArgumentException("This object is not exist in database");
        }
    }
}
