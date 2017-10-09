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

            if (queryObj.SchedulingPod.HasValue)
                query = query.Where(j => j.SchedulingPod == queryObj.SchedulingPod);

            if (queryObj.OfficeId.HasValue)
                query = query.Where(j => j.OfficeId == queryObj.OfficeId);

            if (!string.IsNullOrEmpty(queryObj.JobBoard))
                query = query.Where(j => j.JobBoard.JobBoardName.Contains(queryObj.JobBoard));

            if (!string.IsNullOrEmpty(queryObj.Division))
                query = query.Where(j => j.Division.Contains(queryObj.Division));

            if (!string.IsNullOrEmpty(queryObj.City))
                query = query.Where(j => j.City.Contains(queryObj.City));

            if (!string.IsNullOrEmpty(queryObj.State))
                query = query.Where(j => j.State.StateName.Contains(queryObj.State));

            if (!string.IsNullOrEmpty(queryObj.Country))
                query = query.Where(j => j.Country.CountryName.Contains(queryObj.Country));

            if (!string.IsNullOrEmpty(queryObj.Category))
                query = query.Where(j => j.Category.CategoryName.Contains(queryObj.Category));

            if (!string.IsNullOrEmpty(queryObj.CompanyName))
                query = query.Where(j => j.CompanyName.Contains(queryObj.CompanyName));

            if (!string.IsNullOrEmpty(queryObj.CreatedBy))
                query = query.Where(j => j.CreatedBy.Contains(queryObj.CreatedBy));

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
