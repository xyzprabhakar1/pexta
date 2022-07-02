using Common.CustomAttribute;
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
            ParameterExpression param = Expression.Parameter(typeof(T), "t");
            Expression  selectExpression = source.Expression;
            MethodInfo method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            if ((dtp?.search?.value?.Count() ?? 0) > 2)
            {
                ParameterExpression param1 = Expression.Parameter(typeof(T), "e");
                var srv = Expression.Constant(dtp.search.value, typeof(string));
                var filterCondtion = Expression.Lambda(
                    typeof(T).GetProperties().Where(p => (p.GetCustomAttribute<IsFilterAllowed>()?.IsAllowed ?? false) && p.PropertyType != typeof(DateTime))
                    .Select(p => Expression.Call(MakePropPath(param1, p.Name), method, srv))
                    .Cast<Expression>()
                    .Aggregate(Expression.OrElse), param1);

                selectExpression = Expression.Call(typeof(Queryable), nameof(Queryable.Where), new[] { typeof(T) },
                selectExpression, filterCondtion);
                
            }
            selectExpression = PerformOrderBy(selectExpression);
            
            IQueryable<T> query = source.AsQueryable().Provider.CreateQuery<T>(selectExpression);
            if (dtp?.length > 0)
            {
                query = query.Skip(dtp.start).Take(dtp.length);
            }
            return query;
            Expression PerformOrderBy(Expression Source)
            {
                if ((dtp?.order?.Count ?? 0) > 0)
                {
                    string ColumnName = (dtp?.columns?.Count ?? 0) > dtp.order[0].column ? dtp.columns[dtp.order[0].column].name : "";
                    if (string.IsNullOrEmpty(ColumnName))
                    {
                        return Source;
                    }
                    var OrderProperty=typeof(T).GetProperties().Where(p => p.Name.Equals(ColumnName, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                    if (OrderProperty == null)
                    {
                        return Source;
                    }

                    var OrderCondition=Expression.Lambda(MakePropPath(param, OrderProperty.Name), param);
                    
                    var orderMethod = dtp.order[0].dir == "asc" ? nameof(Queryable.OrderBy) : nameof(Queryable.OrderByDescending);
                    Source = Expression.Call(typeof(Queryable), orderMethod, new[] { typeof(T), OrderProperty.PropertyType },
                    Source, OrderCondition);
                }
                return Source;
                
            }
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
