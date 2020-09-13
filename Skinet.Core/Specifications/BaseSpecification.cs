using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Skinet.Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        {
            
        }
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
            
        }

        //Include the CTOR

        public Expression<Func<T, bool>> Criteria {get;}

        public List<Expression<Func<T, object>>> Includes {get;} = new List<Expression<Func<T, object>>>();

        public Expression<Func<T, object>> OrderBy { get; private set;}

        public Expression<Func<T, object>> OrderByDescending { get; private set;}

        public int Take { get; private set; }

        public int skip { get; private set; }

        public bool IsPagingEnabled { get; private set; }

        protected void AddInclude(Expression<Func<T,object>> IncludeExpression)
        {
            Includes.Add(IncludeExpression);
        }

        protected void AddOrderBy(Expression<Func<T, object>> OrderByExpression)
        {
           OrderBy = OrderByExpression;
        }
        protected void AddOrderByDescending(Expression<Func<T, object>> OrderByDescendingExpression)
        {
            OrderByDescending = OrderByDescendingExpression;
        }

        protected void ApplyPaging(int _skip, int _take)
        {
            skip = _skip;
            Take = _take;
            IsPagingEnabled = true;
        }
    }
}