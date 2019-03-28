using EntityFramework.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KLS.AuthManage.Component.Data.DbService
{
    public class HDbServiceReposity : IHDbServiceReposity, IDisposable
    {
        System.Data.Entity.DbContext _dbContext = null;
        public HDbServiceReposity(DbContext __dbContext)
        {
            _dbContext = __dbContext;
        }
        private bool m_disposed;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~HDbServiceReposity()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    // Release managed resources
                }
                // Release unmanaged resources
                //_dbContext = null;
                m_disposed = true;
            }
        }

        public int Add<T>(T t) where T : class
        {
            PropertyInfo createDate = typeof(T).GetProperty("CreateDate");
            PropertyInfo updateDate = typeof(T).GetProperty("UpdateDate");
            PropertyInfo isDeleted = typeof(T).GetProperty("IsDeleted");
            //默认数据
            if (createDate != null)
            {
                createDate.SetValue(t, DateTime.Now);
            }
            if (updateDate != null)
            {
                updateDate.SetValue(t, DateTime.Now);
            }
            if (isDeleted != null)
            {
                isDeleted.SetValue(t, false);//添加时默认设置为未删除
            }
            _dbContext.Set<T>().Add(t);
            return SaveChanges();
        }

        public int Update<T>(T t) where T : class
        {
            PropertyInfo updateDate = typeof(T).GetProperty("UpdateDate");
            if (updateDate != null)
            {
                updateDate.SetValue(t, DateTime.Now);//默认修改时间
            }
            //typeof(T).GetProperty("UpdateID").SetValue(t, _cacheManager.Get<User>(CacheKeyEnum.CurrentUserKey)?.ID ?? 0);
            _dbContext.Entry<T>(t).State = EntityState.Modified;
            return SaveChanges();
        }

        public int Delete<T>(T t) where T : class
        {
            _dbContext.Entry<T>(t).State = EntityState.Deleted;
            return SaveChanges();
        }

        public IQueryable<T> Where<T>(Expression<Func<T, bool>> whereLambada) where T : class
        {
            return _dbContext.Set<T>().Where(whereLambada);
        }

        public T FirstOrDefault<T>(Expression<Func<T, bool>> whereLamdaba) where T : class
        {
            return _dbContext.Set<T>().Where(whereLamdaba).FirstOrDefault();
        }

        public int Count<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            return _dbContext.Set<T>().Where(predicate).Count();
        }

        public int Sum<T>(Expression<Func<T, bool>> predicateWhere, Expression<Func<T, int>> predicateSelect) where T : class
        {
            return _dbContext.Set<T>().Where(predicateWhere).Select(predicateSelect).Sum();
        }

        public IEnumerable<T> Where<T>(string sql, params object[] paramseters) where T : class
        {
            return _dbContext.Database.SqlQuery<T>(sql, paramseters);
        }

        public int Delete(string sql, params object[] paramseter)
        {
            return _dbContext.Database.ExecuteSqlCommand(sql, paramseter);
        }

        public int Count(string sql, params object[] paramseter)
        {
            return Convert.ToInt32(_dbContext.Database.SqlQuery<decimal>(sql, paramseter).ToList()[0]);
        }

        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }

        public int Update(string sql, params object[] paramseter)
        {
            return _dbContext.Database.ExecuteSqlCommand(sql, paramseter);
        }

        public T Find<T>(object id) where T : class
        {
            return _dbContext.Set<T>().Find(id);
        }

        public int ExecuteSqlCommand(string sql, params object[] parameters)
        {
            return _dbContext.Database.ExecuteSqlCommand(sql, parameters);
        }

        public int ExecuteSqlCommand(TransactionalBehavior transactionalBehavior, string sql, params object[] parameters)
        {
            return _dbContext.Database.ExecuteSqlCommand(transactionalBehavior, sql, parameters);
        }

        public List<T> SelectPageList<T>(int pageIndex, int pagesize, List<T> list)
        {
            var query = from oneItem in list select oneItem;
            return query.Take(pagesize * pageIndex).Skip(pagesize * (pageIndex - 1)).ToList();
        }

        public IQueryable<T> All<T>(params Expression<Func<T, object>>[] includeProperties) where T : class
        {
            return includeProperties.Aggregate<Expression<Func<T, object>>,
               IQueryable<T>>(_dbContext.Set<T>(),
               (set, property) => set.Include(property));
        }

        public List<T> Query<T>(string sql, params object[] paramenters) where T : class
        {
            return _dbContext.Database.SqlQuery<T>(sql, paramenters).ToList();
        }

        public int DeleteByExpression<T>(Expression<Func<T, bool>> predicateWhere) where T : class
        {
            //如果为空将获取整张表数据并删掉整张表
            //var source = predicateWhere == null ? _dbContext.Set<T>() : _dbContext.Set<T>().Where(predicateWhere);
            //如果条件为空返回null数据集合避免删除整张表
            int _num = 0;
            var source = predicateWhere == null ? null : _dbContext.Set<T>().Where(predicateWhere);
            if (source != null)
            {
                _num = source.Delete();
            }
            return _num;
        }

        /// <summary>
        ///   (贪婪加载)查询返回指定实体数据集
        /// </summary>
        /// <param name="includeList">贪婪加载属性集合</param>
        /// <returns>指定实体数据集</returns>
        public IQueryable GetEntitiesByEager<T>(IEnumerable<string> includeList) where T : class
        {
            IQueryable<T> dbset = _dbContext.Set<T>();
            return includeList.Aggregate(dbset, (current, item) => current.Include<T>(item));
        }
    }
}
