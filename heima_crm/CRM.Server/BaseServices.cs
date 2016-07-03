using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CRM.IRepository;
using CRM.IServer;

namespace CRM.Server
{
    public class BaseServices<TEntity> : IBaseServices<TEntity> where TEntity : class
    {
        protected IBaseRepository<TEntity> baseDal;
        public void AddOrUpdate(TEntity entity)
        {
            baseDal.AddOrUpdate(entity);
        }

        public void Delete(TEntity entity)
        {
           baseDal.Delete(entity);
        }

        public IEnumerable<TEntity> QueryByPage<TKey>(Expression<Func<TEntity, bool>> where, Func<TEntity, TKey> keySelector, int pageSize, int pageIndex, out int rowCount, bool isDes = false)
        {
            return baseDal.QueryByPage(where, keySelector, pageSize, pageIndex, out rowCount, isDes);
        }

        public IEnumerable<TEntity> QueryJoin(Expression<Func<TEntity, bool>> where, string[] tableNames)
        {
            return baseDal.QueryJoin(where, tableNames);
        }

        public IEnumerable<TEntity> QueryOrderBy<TKey>(Expression<Func<TEntity, bool>> where, Func<TEntity, TKey> keySelector, bool isDes = false)
        {
            return baseDal.QueryOrderBy<TKey>(where, keySelector, isDes);
        }

        public IEnumerable<TEntity> QueryWhere(Expression<Func<TEntity, bool>> where)
        {
            return baseDal.QueryWhere(where);
        }

        public int SaveChanges()
        {
            return baseDal.SaveChanges();
        }
    }
}
