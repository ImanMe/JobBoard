using JobBoard.Core.DTOs;
using JobBoard.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace JobBoard.Persistence.Extensions
{
    public static class QueryableExtension
    {
        public static IQueryable<Job> ApplyFiltering(this IQueryable<Job> query, JobQuery queryObj)
        {
            if (queryObj.Id.HasValue)
                query = query.Where(j => j.Id == queryObj.Id);

            if (!string.IsNullOrEmpty(queryObj.Title))
                query = query.Where(j => j.Title.Contains(queryObj.Title));

            return query;
        }

        public static IQueryable<T> ApplyOrdering<T>(this IQueryable<T> query, IQueryObject queryObj, Dictionary<string, Expression<Func<T, object>>> columnsMap)
        {
            if (string.IsNullOrWhiteSpace(queryObj.SortBy) || !columnsMap.ContainsKey(queryObj.SortBy))
                return query;

            return queryObj.IsSortAscending
                ? query.OrderBy(columnsMap[queryObj.SortBy])
                : query.OrderByDescending(columnsMap[queryObj.SortBy]);
        }

        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query, IQueryObject queryObj)
        {
            if (queryObj.Page <= 0)
                queryObj.Page = 1;

            if (queryObj.PageSize <= 0)
                queryObj.PageSize = 10;

            return query.Skip((queryObj.Page - 1) * queryObj.PageSize).Take(queryObj.PageSize);
        }
    }


}
