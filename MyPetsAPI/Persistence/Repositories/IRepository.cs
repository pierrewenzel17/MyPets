﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MyPetsAPI.Persistence.Repositories
{
    internal interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity Add(TEntity entity);
        TEntity Update(int id, TEntity entity);
        void Remove(int id);
    }
}
