using Microsoft.EntityFrameworkCore;
using Models;
using Models.HomeService;
using Models.User;
using System.Linq.Dynamic.Core;

namespace Dalel.Repository
{
    public class CategoryServicesRepository : BaseRepository<CategoryServices>
    {
        public CategoryServicesRepository(DelelContext delelContext) : base(delelContext)
        {
        }

        // Get all categories with pagination
        public IQueryable<CategoryServices> GetCategories(
            string searchTerm = null,
            int pageSize = 10,
            int pageNumber = 1)
        {
            IQueryable<CategoryServices> query = GetList();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(c =>
                    c.Name.Contains(searchTerm) ||
                    c.Description.Contains(searchTerm));
            }

            // Apply pagination
            if (pageSize < 1) pageSize = 10;
            if (pageNumber < 1) pageNumber = 1;

            int count = query.Count();
            if (count < pageSize)
            {
                pageSize = count;
                pageNumber = 1;
            }

            int skip = (pageNumber - 1) * pageSize;
            return query.OrderBy(c => c.Name)
                       .Skip(skip)
                       .Take(pageSize);
        }

        // Get category by ID
        public CategoryServices GetCategoryById(int categoryId)
        {
            return GetList(c => c.Id == categoryId).FirstOrDefault();
        }

        // Get all service providers for a specific category
        public IQueryable<ServiceProvider> GetServiceProvidersForCategory(int categoryId)
        {
            var category = GetCategoryById(categoryId);
            return (IQueryable<ServiceProvider>)(category?.ServiceProviders?.ToList() ?? new List<ServiceProvider>());
        }

        // Get paginated service providers for a category
        public IEnumerable<ServiceProvider> GetPaginatedServiceProviders(
            int categoryId,
            int pageSize = 10,
            int pageNumber = 1)
        {
            var providers = GetServiceProvidersForCategory(categoryId).AsQueryable();

            // Apply pagination
            if (pageSize < 1) pageSize = 10;
            if (pageNumber < 1) pageNumber = 1;

            int count = providers.Count();
            if (count < pageSize)
            {
                pageSize = count;
                pageNumber = 1;
            }

            int skip = (pageNumber - 1) * pageSize;
            return providers.OrderBy(p => p.AppUser.UserName)
                           .Skip(skip)
                           .Take(pageSize)
                           .ToList();
        }

        // Get all queries for a specific category
        public IQueryable<ServiceQuaries> GetQueriesForCategory(int categoryId)
        {
            var category = GetCategoryById(categoryId);
            return (IQueryable<ServiceQuaries>)(category?.Quaries?.ToList() ?? new List<ServiceQuaries>());
        }

        // Get paginated queries for a category
        public IQueryable<ServiceQuaries> GetPaginatedQueries(
            int categoryId,
            int pageSize = 10,
            int pageNumber = 1)
        {
            var queries = GetQueriesForCategory(categoryId).AsQueryable();

            // Apply pagination
            if (pageSize < 1) pageSize = 10;
            if (pageNumber < 1) pageNumber = 1;

            int count = queries.Count();
            if (count < pageSize)
            {
                pageSize = count;
                pageNumber = 1;
            }

            int skip = (pageNumber - 1) * pageSize;
            return (IQueryable<ServiceQuaries>)queries.OrderByDescending(q => q.QuestionDate)
                        .Skip(skip)
                        .Take(pageSize)
                        .ToList();
        }

        // Add a new category with optional image path
        public bool AddCategory(string name, string description, string imagePath = null)
        {
            var category = new CategoryServices
            {
                Name = name,
                Description = description,
                Image = imagePath
            };

            base.Add(category);
            return true;
        }

        // Update category image
        public bool UpdateCategoryImage(int categoryId, string newImagePath)
        {
            var category = GetCategoryById(categoryId);
            if (category == null) return false;

            category.Image = newImagePath;
            base.Update(category);
            return true;
        }

        // Get categories with most service providers
        public IQueryable<CategoryServices> GetPopularCategories(int count)
        {
            return (IQueryable<CategoryServices>)GetList()
                  .OrderByDescending(c => c.ServiceProviders.Count)
                  .Take(count)
                  .ToList();
        }
        public class RepositoryException : Exception
        {
            public RepositoryException(string message, Exception innerException)
                : base(message, innerException)
            {
            }
        }

        #region Mahmoud&Osama
        //public async Task<CategoryServices> GetCategoryWithServiceProvidersAsync(int categoryId)
        //{
        //    try
        //    {
        //        var category = await base.GetList()
        //            .FirstOrDefaultAsync(c => c.Id == categoryId);

        //        if (category == null)
        //            throw new KeyNotFoundException($"Category with ID {categoryId} not found");

        //        var providers = category.ServiceProviders?.ToList();
        //        return category;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new RepositoryException(
        //            $"Error retrieving category with service providers (ID: {categoryId})",
        //            ex);
        //    }
        //}

        //public async Task<CategoryServices> GetCategoryWithQueriesAsync(int categoryId)
        //{
        //    try
        //    {
        //        var category = await base.GetList()
        //            .FirstOrDefaultAsync(c => c.Id == categoryId);

        //        if (category == null)
        //            throw new KeyNotFoundException($"Category with ID {categoryId} not found");

        //        // Trigger lazy loading
        //        var queries = category.Quaries?.ToList();
        //        return category;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new RepositoryException(
        //            $"Error retrieving category with queries (ID: {categoryId})",
        //            ex);
        //    }
        //}

        //public async Task<IQueryable<CategoryServices>> GetPopularCategoriesAsync(int count)
        //{
        //    try
        //    {
        //        if (count <= 0)
        //            throw new ArgumentException("Count must be greater than zero", nameof(count));

        //        var categories = await base.GetList()
        //            .OrderByDescending(c => c.ServiceProviders.Count)
        //            .Take(count)
        //            .ToListAsync();

        //        foreach (var category in categories)
        //        {
        //            _ = category.ServiceProviders?.ToList();
        //            _ = category.Quaries?.ToList();
        //        }

        //        return (IQueryable<CategoryServices>)categories;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new RepositoryException(
        //            $"Error retrieving {count} popular categories",
        //            ex);
        //    }
        //}

        //public async Task<bool> CategoryExistsAsync(string name)
        //{
        //    try
        //    {
        //        if (string.IsNullOrWhiteSpace(name))
        //            throw new ArgumentException("Category name cannot be empty", nameof(name));

        //        return await base.GetList()
        //            .AnyAsync(c => c.Name == name);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new RepositoryException(
        //            $"Error checking if category exists (Name: {name})",
        //            ex);
        //    }
        //}

        //public async Task<PagedResult<CategoryServices>> GetPagedCategoriesAsync(
        //    int pageNumber, int pageSize,
        //    string searchTerm = null,
        //    bool includeServiceProviders = false,
        //    bool includeQueries = false)
        //{
        //    try
        //    {
        //        if (pageNumber < 1)
        //            throw new ArgumentException("Page number must be greater than zero", nameof(pageNumber));

        //        if (pageSize < 1)
        //            throw new ArgumentException("Page size must be greater than zero", nameof(pageSize));

        //        var query = base.GetList();

        //        if (!string.IsNullOrWhiteSpace(searchTerm))
        //        {
        //            query = query.Where(c => c.Name.Contains(searchTerm) ||
        //                                 c.Description.Contains(searchTerm));
        //        }

        //        var result = new PagedResult<CategoryServices>
        //        {
        //            pageNumber = pageNumber,
        //            PageSize = pageSize,
        //            TotalCount = await query.CountAsync()
        //        };

        //        var categories = await query
        //            .Skip((pageNumber - 1) * pageSize)
        //            .Take(pageSize)
        //            .ToListAsync();

        //        // Lazy load if requested
        //        if (includeServiceProviders || includeQueries)
        //        {
        //            foreach (var category in categories)
        //            {
        //                if (includeServiceProviders)
        //                    _ = category.ServiceProviders?.ToList();
        //                if (includeQueries)
        //                    _ = category.Quaries?.ToList();
        //            }
        //        }

        //        result.Items = categories;
        //        return result;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new RepositoryException(
        //            $"Error retrieving paged categories (Page: {pageNumber}, Size: {pageSize})",
        //            ex);
        //    }
        //}

        //public async Task<IEnumerable<CategoryServices>> GetPopularCategories(int count)
        //{
        //    try
        //    {
        //        if (count <= 0)
        //            throw new ArgumentException("Count must be greater than zero", nameof(count));

        //        var categories = await base.GetList()
        //            .OrderByDescending(c => c.ServiceProviders.Count)
        //            .Take(count)
        //            .ToListAsync();

        //        // Trigger lazy loading
        //        foreach (var category in categories)
        //        {
        //            _ = category.ServiceProviders?.ToList();
        //            _ = category.Quaries?.ToList();
        //        }

        //        return categories;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new RepositoryException(
        //            $"Error retrieving {count} popular categories",
        //            ex);
        //    }
        //}

        //public CategoryServicesRepository(DelelContext _context) : base(_context) 
        //{

        //}



        //public CategoryServices GetCategoryWithServiceProviders(int categoryId)
        //{
        //    var category = base.GetList(c => c.Id == categoryId).FirstOrDefault();

        //    if (category != null)
        //    {
        //        return category;
        //    }

        //    throw new Exception($"Category with ID {categoryId} not found.");
        //}

        #endregion
        #region Reem


        //public async Task<CategoryServices> GetCategoryWithQueriesAsync(int categoryId)
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