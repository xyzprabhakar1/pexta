using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class LinqHelper
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

        public static IQueryable<T> CurrentData<T>(IQueryable<T> source,string ColumnName= "EffectiveDt")
        {
            DateTime CurrentDate=DateTime.Now;
            var classType = typeof(T);
            PropertyInfo? pi_EffectiveDt = classType.GetProperty(ColumnName);            
            if (pi_EffectiveDt == null)
            {
                return source;
            }
            PropertyInfo? pi_IsActive = classType.GetProperty("IsActive");
            PropertyInfo? pi_IsDeleted= classType.GetProperty("IsDeleted");
            ParameterExpression param = Expression.Parameter(classType, "t");
            var EffectiveDt_ = Expression.Property(param, "EffectiveDt");
            var CurrentDt_ = Expression.Constant(CurrentDate, typeof(DateTime));
            Expression.LessThan(EffectiveDt_, CurrentDt_);
            MemberExpression? IsActive_ = pi_IsActive == null ? null : Expression.Property(param, "IsActive");
            MemberExpression? IsDeleted_ = pi_IsDeleted == null ? null : Expression.Property(param, "IsDeleted");
            LambdaExpression FirstCondition = (IsActive_ != null && IsDeleted_ != null) ? FirstCondition_EffectiveDate_IsActive_IsDeleted():
                (IsActive_ != null && IsDeleted_ == null)? FirstCondition_EffectiveDate_IsActive():
                (IsActive_ == null && IsDeleted_ != null) ? FirstCondition_EffectiveDate_IsDeleted() :
                FirstCondition_EffectiveDate_IsActive()
                ;
            
            

            LambdaExpression FirstCondition_EffectiveDate()
            { 
                return Expression.Lambda(
                Expression.LessThan(EffectiveDt_, CurrentDt_));
            }
            LambdaExpression FirstCondition_EffectiveDate_IsActive()
            {   
                return Expression.Lambda(
                    Expression.AndAlso(
                        Expression.LessThan(EffectiveDt_, CurrentDt_),
                        IsActive_)
                );
            }
            LambdaExpression FirstCondition_EffectiveDate_IsDeleted()
            {
                return Expression.Lambda(
                    Expression.AndAlso(
                        Expression.LessThan(EffectiveDt_, CurrentDt_),
                        Expression.Not( IsDeleted_))
                );
            }
            LambdaExpression FirstCondition_EffectiveDate_IsActive_IsDeleted()
            {
                return Expression.Lambda(
                    Expression.AndAlso(
                    Expression.AndAlso(
                        Expression.LessThan(EffectiveDt_, CurrentDt_),
                        Expression.Not(IsDeleted_)),IsActive_
                    )
                );
            }

            string sortingDir = string.Empty;
            if (sortDirection.ToUpper().Trim() == "ASC")
                sortingDir = "Where";
            else if (sortDirection.ToUpper().Trim() == "DESC")
                sortingDir = "OrderByDescending";
            
            
            PropertyInfo pi = typeof(T).GetProperty(sortExpression);
            pi.Name
            Type[] types = new Type[2];
            types[0] = typeof(T);
            types[1] = pi.PropertyType;
            Expression expr = Expression.Call(typeof(Queryable), sortingDir, types, source.Expression, Expression.Lambda(Expression.Property(param, sortExpression), param));
            IQueryable<T> query = source.AsQueryable().Provider.CreateQuery<T>(expr);
            return query;
        }
    }
}
