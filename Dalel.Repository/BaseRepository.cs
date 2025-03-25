using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Models;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Dalel.Repository
{
    public class BaseRepository<T> where T : class
    {
        #region Properties
        private readonly DelelContext Context;
        protected DbSet<T> Table;

        //protected IDbFactory DbFactory
        //{
        //    get;
        //    private set;
        //}

        //protected StoreEntities DbContext
        //{
        //    get { return dataContext ?? (dataContext = DbFactory.Init()); }
        //}
        #endregion

        protected BaseRepository(DelelContext dbContext)
        {
            Context = dbContext;
            Table = dbContext.Set<T>();
        }
        public IQueryable<T> Get(
           Expression<Func<T, bool>>
           filter = null,
           int pageSize = 4,
           int pageNumber = 1)
        {
            IQueryable<T> query = Table.AsQueryable();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (pageSize < 0)
            {
                pageSize = 4;
            }

            if (pageNumber < 0)
            {
                pageNumber = 1;
            }

            int count = query.Count();

            if (count < pageSize)
            {
                pageSize = count;
                pageNumber = 1;
            }

            int skip = (pageNumber - 1) * pageSize;

            query = query.Skip(skip).Take(pageSize);
            return query;
        }

        public IQueryable<T> GetList(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = Table.AsQueryable();

            if (filter != null) // ✅ Prevents null from causing an exception
            {
                query = query.Where(filter);
            }

            return query;
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
