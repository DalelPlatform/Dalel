using Microsoft.EntityFrameworkCore;
using Models;
using Models.HomeService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dalel.Repository
{
    public class CategoryServicesRepository : BaseRepository<CategoryServices>
    {
        public CategoryServicesRepository(DelelContext context) : base(context)
        {
        }

        public async Task<CategoryServices> GetCategoryWithServiceProvidersAsync(int categoryId)
        {
            try
            {
                var category = await base.GetList()
                    .FirstOrDefaultAsync(c => c.Id == categoryId);

                if (category == null)
                    throw new KeyNotFoundException($"Category with ID {categoryId} not found");

                var providers = category.ServiceProviders?.ToList();
                return category;
            }
            catch (Exception ex)
            {
                throw new RepositoryException(
                    $"Error retrieving category with service providers (ID: {categoryId})",
                    ex);
            }
        }

        public async Task<CategoryServices> GetCategoryWithQueriesAsync(int categoryId)
        {
            try
            {
                var category = await base.GetList()
                    .FirstOrDefaultAsync(c => c.Id == categoryId);

                if (category == null)
                    throw new KeyNotFoundException($"Category with ID {categoryId} not found");

                // Trigger lazy loading
                var queries = category.Quaries?.ToList();
                return category;
            }
            catch (Exception ex)
            {
                throw new RepositoryException(
                    $"Error retrieving category with queries (ID: {categoryId})",
                    ex);
            }
        }

        public async Task<IEnumerable<CategoryServices>> GetPopularCategoriesAsync(int count)
        {
            try
            {
                if (count <= 0)
                    throw new ArgumentException("Count must be greater than zero", nameof(count));

                var categories = await base.GetList()
                    .OrderByDescending(c => c.ServiceProviders.Count)
                    .Take(count)
                    .ToListAsync();

                foreach (var category in categories)
                {
                    _ = category.ServiceProviders?.ToList();
                    _ = category.Quaries?.ToList();
                }

                return categories;
            }
            catch (Exception ex)
            {
                throw new RepositoryException(
                    $"Error retrieving {count} popular categories",
                    ex);
            }
        }

        public async Task<bool> CategoryExistsAsync(string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                    throw new ArgumentException("Category name cannot be empty", nameof(name));

                return await base.GetList()
                    .AnyAsync(c => c.Name == name);
            }
            catch (Exception ex)
            {
                throw new RepositoryException(
                    $"Error checking if category exists (Name: {name})",
                    ex);
            }
        }

        public async Task<PagedResult<CategoryServices>> GetPagedCategoriesAsync(
            int pageNumber, int pageSize,
            string searchTerm = null,
            bool includeServiceProviders = false,
            bool includeQueries = false)
        {
            try
            {
                if (pageNumber < 1)
                    throw new ArgumentException("Page number must be greater than zero", nameof(pageNumber));

                if (pageSize < 1)
                    throw new ArgumentException("Page size must be greater than zero", nameof(pageSize));

                var query = base.GetList();

                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    query = query.Where(c => c.Name.Contains(searchTerm) ||
                                         c.Description.Contains(searchTerm));
                }

                var result = new PagedResult<CategoryServices>
                {
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                    TotalCount = await query.CountAsync()
                };

                var categories = await query
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                // Lazy load if requested
                if (includeServiceProviders || includeQueries)
                {
                    foreach (var category in categories)
                    {
                        if (includeServiceProviders)
                            _ = category.ServiceProviders?.ToList();
                        if (includeQueries)
                            _ = category.Quaries?.ToList();
                    }
                }

                result.Items = categories;
                return result;
            }
            catch (Exception ex)
            {
                throw new RepositoryException(
                    $"Error retrieving paged categories (Page: {pageNumber}, Size: {pageSize})",
                    ex);
            }
        }

        public async Task<IEnumerable<CategoryServices>> GetPopularCategories(int count)
        {
            try
            {
                if (count <= 0)
                    throw new ArgumentException("Count must be greater than zero", nameof(count));

                var categories = await base.GetList()
                    .OrderByDescending(c => c.ServiceProviders.Count)
                    .Take(count)
                    .ToListAsync();

                // Trigger lazy loading
                foreach (var category in categories)
                {
                    _ = category.ServiceProviders?.ToList();
                    _ = category.Quaries?.ToList();
                }

                return categories;
            }
            catch (Exception ex)
            {
                throw new RepositoryException(
                    $"Error retrieving {count} popular categories",
                    ex);
            }
        }
    }

    public class RepositoryException : Exception
    {
        public RepositoryException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}