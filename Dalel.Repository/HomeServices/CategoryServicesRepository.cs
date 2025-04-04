using Models.HomeService;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Dalel.Repository
{
    public class CategoryServicesRepository : BaseRepository<CategoryServices>
    {
        
        public CategoryServicesRepository(DelelContext _context) : base(_context) 
        {
            
        }



        public CategoryServices GetCategoryWithServiceProviders(int categoryId)
        {
            var category = base.GetList(c => c.Id == categoryId).FirstOrDefault();

            if (category != null)
            {
                return category;
            }

            throw new Exception($"Category with ID {categoryId} not found.");
        }


        #region Reem


        //public <CategoryServices> GetCategoryWithQueriesAsync(int categoryId)
        //{
        //    return await context.CategoryServices
        //        .Include(c => c.Quaries)
        //        .FirstOrDefaultAsync(c => c.Id == categoryId);
        //}

        //public async Task<IEnumerable<CategoryServices>> GetPopularCategoriesAsync(int count)
        //{
        //    return await context.CategoryServices
        //        .OrderByDescending(c => c.ServiceProviders.Count)
        //        .Take(count)
        //        .ToListAsync();
        //}

        //public async Task<bool> CategoryExistsAsync(string name)
        //{
        //    return await context.CategoryServices
        //        .AnyAsync(c => c.Name == name);
        //}

        
        
        //public async Task<PagedResult<CategoryServices>> GetPagedCategoriesAsync(
        //    int pageNumber, int pageSize,
        //    string searchTerm = null,
        //    bool includeServiceProviders = false,
        //    bool includeQueries = false)
        //{
        //    var query = context.CategoryServices.AsQueryable();

        //    if (!string.IsNullOrEmpty(searchTerm))
        //    {
        //        query = query.Where(c => c.Name.Contains(searchTerm) ||
        //                         c.Description.Contains(searchTerm));
        //    }

        //    if (includeServiceProviders)
        //    {
        //        query = query.Include(c => c.ServiceProviders);
        //    }

        //    if (includeQueries)
        //    {
        //        query = query.Include(c => c.Quaries);
        //    }

        //    var result = new PagedResult<CategoryServices>
        //    {
        //        PageNumber = pageNumber,
        //        PageSize = pageSize,
        //        TotalCount = await query.CountAsync()
        //    };

        //    result.Items = await query
        //        .Skip((pageNumber - 1) * pageSize)
        //        .Take(pageSize)
        //        .ToListAsync();

        //    return result;
        //}

        //public async Task<PagedResult<CategoryServices>> FilterCategoriesAsync(
        //    string name = null,
        //    bool? hasServiceProviders = null,
        //    bool? hasQueries = null,
        //    int pageNumber = 1,
        //    int pageSize = 10,
        //    string sortBy = "Name",
        //    bool ascending = true)
        //{
        //    var query = context.CategoryServices.AsQueryable();

        //    if (!string.IsNullOrEmpty(name))
        //    {
        //        query = query.Where(c => c.Name.Contains(name));
        //    }

        //    if (hasServiceProviders.HasValue)
        //    {
        //        query = hasServiceProviders.Value
        //            ? query.Where(c => c.ServiceProviders.Any())
        //            : query.Where(c => !c.ServiceProviders.Any());
        //    }

        //    if (hasQueries.HasValue)
        //    {
        //        query = hasQueries.Value
        //            ? query.Where(c => c.Quaries.Any())
        //            : query.Where(c => !c.Quaries.Any());
        //    }

        //    // Sorting
        //    query = sortBy switch
        //    {
        //        "Name" => ascending ? query.OrderBy(c => c.Name) : query.OrderByDescending(c => c.Name),
        //        "Id" => ascending ? query.OrderBy(c => c.Id) : query.OrderByDescending(c => c.Id),
        //        _ => query.OrderBy(c => c.Name)
        //    };

        //    var result = new PagedResult<CategoryServices>
        //    {
        //        PageNumber = pageNumber,
        //        PageSize = pageSize,
        //        TotalCount = await query.CountAsync()
        //    };

        //    result.Items = await query
        //        .Skip((pageNumber - 1) * pageSize)
        //        .Take(pageSize)
        //        .ToListAsync();

        //    return result;
        //}




        //public IQueryable<CategoryServices> GetPopularCategories(int count)
        //{
        //    return GetList()
        //        .OrderByDescending(c => c.ServiceProviders.Count)
        //        .Take(count);
        //}
        #endregion


     

    }
}
