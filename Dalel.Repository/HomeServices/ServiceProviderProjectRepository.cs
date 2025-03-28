using Models.HomeService;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Dalel.Repository
{
    public class ServiceProviderProjectRepository : BaseRepository<ServiceProviderProject>
    {
        private readonly DelelContext _context;

        public ServiceProviderProjectRepository(DelelContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ServiceProviderProject>> GetProjectsByProviderAsync(string providerId)
        {
            return await _context.ServiceProviderProjects
                .Where(p => p.ServiceProviderId == providerId)
                .OrderByDescending(p => p.Id)
                .ToListAsync();
        }

        public async Task AddProjectAsync(ServiceProviderProject project, string imagePath = null)
        {
            if (!string.IsNullOrEmpty(imagePath))
            {
                project.Image = imagePath;
            }

            await _context.ServiceProviderProjects.AddAsync(project);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProjectImageAsync(int projectId, string newImagePath)
        {
            var project = await _context.ServiceProviderProjects.FindAsync(projectId);
            if (project != null)
            {
                project.Image = newImagePath;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<PagedResult<ServiceProviderProject>> FilterProjectsAsync(
            string providerId = null,
            int? categoryId = null,
            string searchTerm = null,
            bool? hasImage = null,
            int pageNumber = 1,
            int pageSize = 10,
            string sortBy = "Name",
            bool ascending = true)
        {
            var query = _context.ServiceProviderProjects
                .Include(p => p.ServiceProvider)
                .ThenInclude(sp => sp.CategoryServices)
                .AsQueryable();

            if (!string.IsNullOrEmpty(providerId))
            {
                query = query.Where(p => p.ServiceProviderId == providerId);
            }

            if (categoryId.HasValue)
            {
               query = query.Where(p => p.ServiceProvider.CategoryServicesId == categoryId.Value);
            }

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(p => p.Name.Contains(searchTerm) || p.Description.Contains(searchTerm));
            }

            if (hasImage.HasValue)
            {
                query = hasImage.Value 
                    ? query.Where(p => !string.IsNullOrEmpty(p.Image))
                    : query.Where(p => string.IsNullOrEmpty(p.Image));
            }

            // Sorting
            query = sortBy switch
            {
                "Name" => ascending 
                    ? query.OrderBy(p => p.Name) 
                    : query.OrderByDescending(p => p.Name),
                "Date" => ascending
                    ? query.OrderBy(p => p.Id)
                    : query.OrderByDescending(p => p.Id),
                _ => query.OrderBy(p => p.Name)
            };

            return await GetPagedAsync(
                pageNumber: pageNumber,
                pageSize: pageSize,
                filter: query,
                orderBy: ascending ? (Func<IQueryable<ServiceProviderProject>, IOrderedQueryable<ServiceProviderProject>>)(q => q.OrderBy(p => p.Name)) 
                          : q => q.OrderByDescending(p => p.Name));
        }

        public async Task<IEnumerable<ServiceProviderProject>> GetFeaturedProjectsAsync(int count)
        {
            return await _context.ServiceProviderProjects
                .Where(p => !string.IsNullOrEmpty(p.Image))
                .OrderByDescending(p => p.Id)
                .Take(count)
                .ToListAsync();
        }
    }
}