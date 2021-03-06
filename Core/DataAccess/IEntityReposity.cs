﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core
{
    public interface IEntityReposity<T> where T: class,IEntity,new()
    {
        
        T Get(Expression<Func<T,bool>> filter);

        List<T> GetAll(Expression<Func<T, bool>> filter=null);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
