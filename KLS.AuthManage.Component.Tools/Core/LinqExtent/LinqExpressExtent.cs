using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KLS.AuthManage.Component.Tools.Core.LinqExtent
{
    public static class LinqExpressExtent
    {
        /// <summary>
        /// 动态查询方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryable"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static IQueryable<T> Where<T>(this IQueryable<T> queryable, T t) where T : class, new()
        {
            ParameterExpression param = Expression.Parameter(typeof(T), typeof(T).Name);
            var properties = t.GetType().GetProperties();
            Expression orExpression = null;
            foreach (var prop in properties)
            {
                var keyAttr = (KeyAttribute)Attribute.GetCustomAttribute(prop, typeof(KeyAttribute));
                var name = prop.Name;
                var value = prop.GetValue(t);
                if (keyAttr != null)
                    continue;
                if (value == null || value.ToString() == "0")
                    continue;
                if (name == "PageIndex" || name == "PageSize" || name == "IsExport" || name == "IsImport")
                    continue;
                if (name.StartsWith("View_") || name.EndsWith("Str"))
                    continue;
                if (name == "OrderName" || name == "SortName")
                    continue;
                //if (name == "UpdateDate" || name == "CreateDate")
                //    continue;
                //if (name == "IsDeleted")
                //{
                //    if ((bool)value != false) {
                //        continue;
                //    }
                //}
                Expression left = Expression.Property(param, typeof(T).GetProperty(name));
                Expression right = Expression.Constant(value);
                Expression filter = Expression.Equal(left, right);
                if (prop.PropertyType == typeof(string))
                {
                    filter = Expression.Call(left, typeof(string).GetMethod("Contains"), right);
                }
                if (prop.PropertyType == typeof(DateTime) || prop.PropertyType == typeof(DateTime?))
                {
                    if (right.ToString() == "0001/1/1 0:00:00")
                        continue;
                    if (prop.Name.ToLower().Contains("start"))
                    {
                        filter = Expression.GreaterThanOrEqual(left, right);
                    }
                    if (prop.Name.ToLower().Contains("end"))
                    {
                        filter = Expression.LessThanOrEqual(left, right);
                    }
                }
                if (orExpression == null)
                {
                    orExpression = Expression.Constant(true);
                }
                orExpression = Expression.And(orExpression, filter);
            }
            if (orExpression != null)
            {
                Expression pred = Expression.Lambda(orExpression, param);
                Expression expr = Expression.Call(typeof(Queryable), "Where", new Type[] { typeof(T) }, Expression.Constant(queryable), pred);
                queryable = queryable.Provider.CreateQuery<T>(expr);
            }

            return queryable;
        }

        /// <summary>
        /// 分页方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryable"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static IQueryable<T> ToPaginationList<T>(this IQueryable<T> queryable, int pageIndex, int pageSize) where T : class, new()
        {
            return queryable.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }
    }
}
