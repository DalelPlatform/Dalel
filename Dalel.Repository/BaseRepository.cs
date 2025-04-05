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




       

      


    }
}
