using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
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
        public IQueryable<T> Get(
            Expression<Func<T, bool>> filter = null,
            int pageSize = 4,
            int pageNumber = 1)
        {
            IQueryable<T> query = Table.AsQueryable();

            if (filter != null)
            {
                query = query.Where(filter);
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
        #endregion



        #region CRUD Operations
        public async Task<T> GetByIdAsync(int id) => await Table.FindAsync(id);
        public async Task<IEnumerable<T>> GetAllAsync() => await Table.ToListAsync();
        public async Task AddAsync(T entity) => await Table.AddAsync(entity);
        public void UpdateAsyn(T entity) => Context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        public void DeleteAsyn(T entity) => Table.Remove(entity);
        public async Task<bool> SaveChangesAsync() => await Context.SaveChangesAsync() > 0;
        #endregion

        #region Query Operations
        public async Task<PagedResult<T>> GetPagedAsync(
            int pageNumber = 1,
            int pageSize = 10,
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = Table;

            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            var result = new PagedResult<T>
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = await query.CountAsync()
            };

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            result.Items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return result;
        }

        public async Task<IEnumerable<T>> FindAsync(
            Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = Table;

            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            query = query.Where(predicate);

            return orderBy != null
                ? await orderBy(query).ToListAsync()
                : await query.ToListAsync();
        }
        #endregion

        public class PagedResult<TResult>
        {
            public IEnumerable<TResult> Items { get; set; }
            public int TotalCount { get; set; }
            public int PageNumber { get; set; }
            public int PageSize { get; set; }
            public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);


            #region Implementation
            /*  public virtual void Add(T entity)
              {
                  Table.Add(entity);
              }

              public virtual void Update(T entity)
              {
                  Table.Attach(entity);
                  Context.Entry(entity).State = EntityState.Modified;
              }

              public virtual void Delete(T entity)
              {
                  Table.Remove(entity);
              }

              public virtual void Delete(Expression<Func<T, bool>> where)
              {
                  IEnumerable<T> objects = Table.Where<T>(where).AsEnumerable();
                  foreach (T obj in objects)
                      Table.Remove(obj);
              }

              public virtual T GetById(int id)
              {
                  return Table.Find(id);
              }

              public IEnumerable<T> GetAll()
              {
                  return Table.ToList();
              }

              public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
              {
                  return Table.Where(where).ToList();
              }

              public T Get(Expression<Func<T, bool>> where)
              {
                  return Table.Where(where).FirstOrDefault<T>();
              } 
            */
            #endregion

        }
    }
}
