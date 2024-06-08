﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EgitimTakip.Repository.Shared.Abstract
{
    public interface IRepository<T> where T : class
    {
        ICollection<T> GetAll();
        T Add(T entity);
        List<T> AddRange();
        T Update(T entity);
        T Delete(int id);
        T GetById(int id);
        
        T GetFirstOrDefault(Expression<Func<T,bool>> predicate);
        void Save();


    }
}
