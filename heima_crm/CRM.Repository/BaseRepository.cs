using CRM.IRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Repository
{
   public  class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity:class 
    {
       BaseDbContext db
       {
           get
           {
               var obj = CallContext.GetData("BaseDbContext");
               if (obj==null    )
               {
                    obj=new BaseDbContext();
                   CallContext.SetData("BaseDbContext", obj);
               }
               return obj as BaseDbContext;
           }
       }
       DbSet<TEntity> _dbset;

       public BaseRepository()
       {
           _dbset = db.Set<TEntity>();
       }

        #region 查询
        public IEnumerable<TEntity> QueryWhere(Expression<Func<TEntity, bool>> where)
        {
            return _dbset.Where(where).ToList();
        }

        public IEnumerable<TEntity> QueryJoin(Expression<Func<TEntity, bool>> where, string[] tableNames)
        {
            IQueryable<TEntity> Tqueryable = null;
            foreach (var tableName in tableNames)
            {
                Tqueryable = _dbset.Include(tableName);
            }
            return Tqueryable.ToList();
        }

        public IEnumerable<TEntity> QueryOrderBy<TKey>(Expression<Func<TEntity, bool>> where, Func<TEntity, TKey> keySelector, bool isDes = false)
        {
            return isDes == false
                ? QueryWhere(where).OrderBy(keySelector).ToList()
                : QueryWhere(where).OrderByDescending(keySelector).ToList();

        }

        public IEnumerable<TEntity> QueryByPage<TKey>(Expression<Func<TEntity, bool>> where, Func<TEntity, TKey> keySelector, int pageSize, int pageIndex, out int rowCount, bool isDes = false)
        {
            int skipCount = (pageIndex - 1) * pageSize;
            rowCount = QueryWhere(where).Count();

            return QueryOrderBy(where, keySelector).Skip(skipCount).Take(pageSize);
        }
        #endregion
        #region 增删改

       public void AddOrUpdate(TEntity entity)
       {
           
               _dbset.AddOrUpdate(entity);
           
       }

       public void Delete(TEntity entity)
       {
           if (db.Entry(entity).State == EntityState.Detached)
           {
               _dbset.Attach(entity);
           }

           _dbset.Remove(entity);
       }
        #endregion

       public int SaveChanges()
       {
           return db.SaveChanges();
       }
    }
}
