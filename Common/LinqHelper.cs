using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class LinqHelper
    {
        public static IQueryable<T> DataSorting<T>(IQueryable<T> source, string sortExpression, string sortDirection)
        {
            string sortingDir = string.Empty;
            if (sortDirection.ToUpper().Trim() == "ASC")
                sortingDir = "OrderBy";
            else if (sortDirection.ToUpper().Trim() == "DESC")
                sortingDir = "OrderByDescending";
            ParameterExpression param = Expression.Parameter(typeof(T), sortExpression);
            PropertyInfo pi = typeof(T).GetProperty(sortExpression);
            Type[] types = new Type[2];
            types[0] = typeof(T);
            types[1] = pi.PropertyType;
            Expression expr = Expression.Call(typeof(Queryable), sortingDir, types, source.Expression, Expression.Lambda(Expression.Property(param, sortExpression), param));
            IQueryable<T> query = source.AsQueryable().Provider.CreateQuery<T>(expr);
            return query;
        }

        public static IQueryable<T> DataFilter<T>(IQueryable<T> source, DataTableParameters dtp)
        {
            if (!string.IsNullOrEmpty(dtp?.search?.value))
            { 
            }
                string sortingDir = string.Empty;
            if (sortDirection.ToUpper().Trim() == "ASC")
                sortingDir = "OrderBy";
            else if (sortDirection.ToUpper().Trim() == "DESC")
                sortingDir = "OrderByDescending";
            ParameterExpression param = Expression.Parameter(typeof(T), sortExpression);
            PropertyInfo pi = typeof(T).GetProperty(sortExpression);
            Type[] types = new Type[2];
            types[0] = typeof(T);
            types[1] = pi.PropertyType;
            Expression expr = Expression.Call(typeof(Queryable), sortingDir, types, source.Expression, Expression.Lambda(Expression.Property(param, sortExpression), param));
            IQueryable<T> query = source.AsQueryable().Provider.CreateQuery<T>(expr);
            return query;
        }

        public static IQueryable<T> CurrentData<T>(
            this IQueryable<T> source,
            string distinctPropName,
            string maxPropName)
        {
            var entityParam = Expression.Parameter(typeof(T), "e");
            var distinctBy = Expression.Lambda(MakePropPath(entityParam, distinctPropName), entityParam);
            var maxBy = Expression.Lambda(MakePropPath(entityParam, maxPropName), entityParam);
            var queryExpression = Expression.Call(typeof(LinqHelper), nameof(LinqHelper.CurrentData),
                new[] { typeof(T), distinctBy.Body.Type, maxBy.Body.Type },
                Expression.Constant(source),
                Expression.Quote(distinctBy),
                Expression.Quote(maxBy));
            var executionLambda = Expression.Lambda<Func<IQueryable<T>>>(queryExpression);
            return executionLambda.Compile()();
        }

        public static IQueryable<T> CurrentData<T, TKey, TMax>(
            this IQueryable<T> source,
            Expression<Func<T, TKey>> distinctBy,
            Expression<Func<T, TMax>> maxBy)
        {
            var distinctQuery = source.Select(distinctBy).Distinct();

            var distinctParam = Expression.Parameter(typeof(TKey), "d");
            var entityParam = distinctBy.Parameters[0];

            var mapping = MapMembers(distinctBy.Body, distinctParam).ToList();

            var orderParam = maxBy.Parameters[0];
            var oderMapping = CollectMembers(maxBy.Body).ToList();

            var whereExpr = mapping.Select(t => Expression.Equal(t.Item1, t.Item2))
                .Aggregate(Expression.AndAlso);
            var whereLambda = Expression.Lambda(whereExpr, entityParam);

            // d => query.Where(x => d.distinctBy == x.distinctBy).Take(1)
            Expression selectExpression = Expression.Call(typeof(Queryable), nameof(Queryable.Where), new[] { typeof(T) },
                source.Expression,
                whereLambda);

            // prepare OrderByPart
            for (int i = 0; i < oderMapping.Count; i++)
            {
                var orderMethod = i == 0 ? nameof(Queryable.OrderByDescending) : nameof(Queryable.ThenByDescending);

                var orderItem = oderMapping[i];
                selectExpression = Expression.Call(typeof(Queryable), orderMethod, new[] { typeof(T), orderItem.Type },
                    selectExpression, Expression.Lambda(orderItem, orderParam));
            }

            // Take(1)
            selectExpression = Expression.Call(typeof(Queryable), nameof(Queryable.Take), new[] { typeof(T) },
                selectExpression,
                Expression.Constant(1));

            var selectManySelector =
                Expression.Lambda<Func<TKey, IEnumerable<T>>>(selectExpression, distinctParam);

            var selectManyQuery = Expression.Call(typeof(Queryable), nameof(Queryable.SelectMany),
                new[] { typeof(TKey), typeof(T) }, distinctQuery.Expression, selectManySelector);

            return source.Provider.CreateQuery<T>(selectManyQuery);
        }

        static Expression MakePropPath(Expression objExpression, string path)
        {
            return path.Split('.').Aggregate(objExpression, Expression.PropertyOrField);
        }

        private static IEnumerable<Tuple<Expression, Expression>> MapMembers(Expression expr, Expression projectionPath)
        {
            switch (expr.NodeType)
            {
                case ExpressionType.New:
                    {
                        var ne = (NewExpression)expr;

                        for (int i = 0; i < ne.Arguments.Count; i++)
                        {
                            foreach (var e in MapMembers(ne.Arguments[i], Expression.MakeMemberAccess(projectionPath, ne.Members[i])))
                            {
                                yield return e;
                            }
                        }
                        break;
                    }

                default:
                    yield return Tuple.Create(projectionPath, expr);
                    break;
            }
        }

        private static IEnumerable<Expression> CollectMembers(Expression expr)
        {
            switch (expr.NodeType)
            {
                case ExpressionType.New:
                    {
                        var ne = (NewExpression)expr;

                        for (int i = 0; i < ne.Arguments.Count; i++)
                        {
                            yield return ne.Arguments[i];
                        }
                        break;
                    }

                default:
                    yield return expr;
                    break;
            }
        }

    }

    //public static class QueryableExtensions
    //{
        
    //}
}
