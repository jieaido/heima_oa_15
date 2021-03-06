﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CRM.IRepository
{
    
        public interface IBaseRepository<TEntity> where TEntity : class
        {
            void AddOrUpdate(TEntity entity);
            void Delete(TEntity entity);
            IEnumerable<TEntity> QueryByPage<TKey>(Expression<Func<TEntity, bool>> where, Func<TEntity, TKey> keySelector, int pageSize, int pageIndex, out int rowCount, bool isDes = false);
            IEnumerable<TEntity> QueryJoin(Expression<Func<TEntity, bool>> where, string[] tableNames);
            IEnumerable<TEntity> QueryOrderBy<TKey>(Expression<Func<TEntity, bool>> where, Func<TEntity, TKey> keySelector, bool isDes = false);
            IEnumerable<TEntity> QueryWhere(Expression<Func<TEntity, bool>> where);
            int SaveChanges();
        }

}
