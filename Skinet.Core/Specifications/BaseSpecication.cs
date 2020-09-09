using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Skinet.Core.Specifications
{
    public class BaseSpecication<T> : ISpecification<T>
    {
        public BaseSpecication()
        {
            
        }
        public BaseSpecication(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
            
        }

        //Include the CTOR

        public Expression<Func<T, bool>> Criteria {get;}

        public List<Expression<Func<T, object>>> Includes {get;} = new List<Expression<Func<T, object>>>();

        protected void AddInclude(Expression<Func<T,object>> IncludeExpression)
        {
            Includes.Add(IncludeExpression);
        }
    }
}