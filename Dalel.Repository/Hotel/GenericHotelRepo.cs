using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Dalel.Repository.GenericHotelRepo
{
    public class GenericHotelRepo<T> : IGenericHotelRepo<T> where T : class
    {
        private readonly DelelContext _context;
        private readonly DbSet<T> _table;

        public GenericHotelRepo(DelelContext context)
        {
            _context = context;
            _table = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _table.ToListAsync();
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await _table.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await _table.Where(expression).ToListAsync();
        }

        public async Task InsertAsync(T obj)
        {
            await _table.AddAsync(obj);
        }

        public async Task UpdateAsync(T obj)
        {
            _table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(object id)
        {
            T existing = await _table.FindAsync(id);
            if (existing != null)
                _table.Remove(existing);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
