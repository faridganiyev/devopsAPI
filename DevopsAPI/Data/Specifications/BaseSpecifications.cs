﻿using System.Linq.Expressions;

namespace DevopsAPI.Data.Specifications
{
    public class BaseSpecifications<T> : ISpecifications<T>
    {
        public BaseSpecifications()
        {

        }

        public BaseSpecifications(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<T, bool>> Criteria { get; }

        public List<Expression<Func<T, object>>> Includes => new();

        public Expression<Func<T, object>> OrderBy { get; private set; }

        public Expression<Func<T, object>> OrderByDescending { get; private set; }

        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool IsPagingEnabled { get; private set; }



        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        public void AddOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        public void AddOrderByDescending(Expression<Func<T, object>> orderByDescending)
        {
            OrderByDescending = orderByDescending;
        }

        public void ApplyPaging(int take, int skip)
        {
            take = take;
            skip = skip;
            IsPagingEnabled = true;
        }
    }
}
