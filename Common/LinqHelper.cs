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

        private class GroupByEffectiveDate1
        {
            public uint sno { get; set; }
            public uint ?Id { get; set; }
            public DateTime EffectiveDt { get; set; }
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

            //Expression expr = Expression.Call(typeof(Queryable), "Where", new Type[] { source.ElementType },  source.Expression, Condition1);
            //IQueryable<T> query = source.AsQueryable().Provider.CreateQuery<T>(expr);
            IQueryable <T> query = source.Where(Condition1);

            //IQueryable<GroupByEffectiveDate1> query1 = query.Select();
            var Condition2 = Expression.Lambda<Func<T, uint>>(GroupBy_);
            var Condition3 = Expression.Lambda<Func<T,DateTime>>(EffectiveDt_);
            var gr = query.GroupBy(Condition2);
            
            ParameterExpression param1 = Expression.Parameter(typeof(IGrouping<uint,T>), "p");
            MemberExpression p1 = Expression.Property(param1, "Key");
            var expr = Expression.Call(typeof(Queryable), "Max", new Type[] { source.ElementType },  source.Expression, Condition3);
            Expression.New(typeof(GroupByEffectiveDate1));






            var gr1 = Expression.Call(typeof(Queryable), "Select", new Type[] { gr.ElementType }, gr.Expression, Condition3);



            return query;
        }
    }
}
