using Dalel.ViewModels;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace Dalel.Repository
{
    public class BaseRepository<T> where T : class
    {
        protected readonly DelelContext Context;
        protected readonly Microsoft.EntityFrameworkCore.DbSet<T> Table;

        public BaseRepository(DelelContext dbContext)
        {
            Context = dbContext;
            Table = dbContext.Set<T>();
        }

        #region Existing Methods (Maintained for backward compatibility)

        public PaginationViewModel<TViewModel> Search<TViewModel, TKey>(
             Expression<Func<T, bool>> filterPredicate,
             Expression<Func<T, TKey>> orderBy,
             Func<T, TViewModel> selector,
             bool descending = false,
             int pageSize = 5,
             int pageIndex = 1)
        {
            var query = GetSortedFilter(orderBy, filterPredicate, !descending);
            var totalCount = query.Count();

            var data = query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .Select(selector)
                .ToList();

            return new PaginationViewModel<TViewModel>
            {
                Data = data,
                TotalCount = totalCount,
                PageNumber = pageIndex,
                PageSize = pageSize
            };
        }
        protected  IQueryable<T> GetSortedFilter<TKey>(
         Expression<Func<T, TKey>> orderBy,
         Expression<Func<T, bool>> filter,
         bool ascending = true)
        {
            var query = Table.AsQueryable();

            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = ascending ? query.OrderBy(orderBy) : query.OrderByDescending(orderBy);

            return query;
        }


        public IQueryable<T> Get(
            Expression<Func<T, bool>> filter = null,
            int pageSize = 4,
            int pageNumber = 1,
            string? orderBy="Id",
            bool isAscebding = false)
        {
            IQueryable<T> query = Table.AsQueryable();

            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (!string.IsNullOrEmpty(orderBy))
            {
                query.Sort(orderBy, isAscebding);
            }

            if (pageSize < 0) pageSize = 4;
            if (pageNumber < 0) pageNumber = 1;

            int count = query.Count();
            if (count < pageSize)
            {
                pageSize = count;
                pageNumber = 1;
            }

            int skip = (pageNumber - 1) * pageSize;
            return query.Skip(skip).Take(pageSize);
        }

        public IQueryable<T> GetList(Expression<Func<T, bool>> filter = null)
        {
            return filter != null ? Table.Where(filter) : Table;
        }




        public void Add(T newRow)
        {
            Table.Add(newRow);
            Context.SaveChanges();
        }

        public void Update(T newRow)
        {
            Table.Update(newRow);
            Context.SaveChanges();
        }

        public void Delete(T row)
        {
            Table.Remove(row);
            Context.SaveChanges();
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        

        #endregion









       }
}
