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

        public static IQueryable<T> CurrentData<T>(IQueryable<T> source,string GroupColumnName= "EmpId", string DateColumnName= "EffectiveDt") where T : class
        {   
            DateTime CurrentDate=DateTime.Now;
            Type classType = typeof(T);
            PropertyInfo? pi_EffectiveDt_ = classType.GetProperty(DateColumnName);
            PropertyInfo? pi_GroupBy_ = classType.GetProperty(GroupColumnName);
            if (pi_EffectiveDt_ == null)
            {
                throw new Exception("Invalid column Name");
            }
            if (pi_GroupBy_ == null)
            {
                throw new Exception("Invalid column Name");
            }
            PropertyInfo pi_EffectiveDt = pi_EffectiveDt_;
            PropertyInfo pi_GroupBy = pi_GroupBy_;

            PropertyInfo? pi_IsActive = classType.GetProperty("IsActive");
            PropertyInfo? pi_IsDeleted= classType.GetProperty("IsDeleted");
            ParameterExpression param = Expression.Parameter(classType, "t");

            MemberExpression EffectiveDt_ = Expression.Property(param, DateColumnName);
            MemberExpression GroupBy_ = Expression.Property(param, GroupColumnName);
            
            var CurrentDt_ = Expression.Constant(CurrentDate, typeof(DateTime));
            var tempbool_ = Expression.Constant(true, typeof(bool));
            Expression.LessThan(EffectiveDt_, CurrentDt_);
            MemberExpression? IsActive_ = pi_IsActive == null ? null : Expression.Property(param, "IsActive");
            MemberExpression? IsDeleted_ = pi_IsDeleted == null ? null : Expression.Property(param, "IsDeleted");

            var Condition1 =
            ((IsActive_ != null && IsDeleted_ != null) ? Expression.Lambda<Func<T, bool>>(Expression.AndAlso(Expression.AndAlso(Expression.LessThan(EffectiveDt_, CurrentDt_),Expression.Not(IsDeleted_)), IsActive_), new ParameterExpression[] { param }):
            (IsActive_ != null && IsDeleted_ == null)? Expression.Lambda<Func<T, bool>>(Expression.AndAlso(Expression.LessThan(EffectiveDt_, CurrentDt_),IsActive_), new ParameterExpression[] { param }) :
            (IsActive_ == null && IsDeleted_ != null) ? Expression.Lambda<Func<T, bool>>(Expression.AndAlso(Expression.LessThan(EffectiveDt_, CurrentDt_),Expression.Not(IsDeleted_)), new ParameterExpression[] { param }) :
            Expression.Lambda<Func<T, bool>>(Expression.LessThan(EffectiveDt_, CurrentDt_), new ParameterExpression[] { param }));
            
            var Condition2 = Expression.Lambda<T,Tkey>(GroupBy_);
            IQueryable <T> query = source.Where(Condition1).GroupBy(Condition2) ;

            


            
            return query;
        }
    }
}
