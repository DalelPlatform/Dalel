using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.Repository.GenericHotelRepo
{
    public class GenericHotelRepo<T> : IGenericHotelRepo<T> where T : class
    {
        private DelelContext _context = null;


        
        private DbSet<T> table = null;

        public GenericHotelRepo(DelelContext context)
        {
          _context = context;
            table = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetById(object id)
        {
            return table.Find(id);
        }
        // Get entities by condition
        public IEnumerable<T> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return table.Where(expression).ToList();
        }

        public void Insert(T obj)
        {
           
            table.Add(obj);
        }

        public void Update(T obj)
        {
           
            table.Attach(obj);
           
            _context.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            T existing = table.Find(id);

            table.Remove(existing);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
