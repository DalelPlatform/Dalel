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

        }

        public IQueryable<ServiceProviderProject> GetProjects(string serviceProviderId)
        {
            return base.GetList(p => p.ServiceProviderId == serviceProviderId).OrderByDescending(p => p.Id);
        }

        public void AddProject(ServiceProviderProject project, string imagePath = null)
        {
            if (!string.IsNullOrEmpty(imagePath))
            {
                project.ProjectImages = imagePath;
            }
            base.Add(project);
            base.Save();

        }

        public void UpdateProject(ServiceProviderProject project)
        {
            base.Update(project);
            base.Save();
        }

        public void UpdateProjectImage(int projectId, string newImagePath)
        {
            var project = base.Get(p => p.Id == projectId).FirstOrDefault();
            if (project != null)
            {
                project.ProjectImages = newImagePath;
                base.Update(project);
                base.Save();
            }
        }

        public void DeleteProject(int projectId)
        {
            var project = base.Get(p => p.Id == projectId).FirstOrDefault();
            if (project != null)
            {
                base.Delete(project);
                base.Save();
            }
        }

        //public async Task<PagedResult<ServiceProviderProject>> FilterProjectsAsync(
        //    string providerId = null,
        //    int? categoryId = null,
        //    string searchTerm = null,
        //    bool? hasImage = null,
        //    int pageNumber = 1,
        //    int pageSize = 10,
        //    string sortBy = "Name",
        //    bool ascending = true)
        //{
        //    var query = _context.ServiceProviderProjects
        //        .Include(p => p.ServiceProvider)
        //        .ThenInclude(sp => sp.CategoryServices)
        //        .AsQueryable();

        //    if (!string.IsNullOrEmpty(providerId))
        //    {
        //        query = query.Where(p => p.ServiceProviderId == providerId);
        //    }

        //    if (categoryId.HasValue)
        //    {
        //       query = query.Where(p => p.ServiceProvider.CategoryServicesId == categoryId.Value);
        //    }

        //    if (!string.IsNullOrEmpty(searchTerm))
        //    {
        //        query = query.Where(p => p.Name.Contains(searchTerm) || p.Description.Contains(searchTerm));
        //    }

        //    if (hasImage.HasValue)
        //    {
        //        query = hasImage.Value 
        //            ? query.Where(p => !string.IsNullOrEmpty(p.Image))
        //            : query.Where(p => string.IsNullOrEmpty(p.Image));
        //    }

        //    // Sorting
        //    query = sortBy switch
        //    {
        //        "Name" => ascending 
        //            ? query.OrderBy(p => p.Name) 
        //            : query.OrderByDescending(p => p.Name),
        //        "Date" => ascending
        //            ? query.OrderBy(p => p.Id)
        //            : query.OrderByDescending(p => p.Id),
        //        _ => query.OrderBy(p => p.Name)
        //    };

        //    return await GetPagedAsync(
        //        pageNumber: pageNumber,
        //        pageSize: pageSize,
        //        filter: query,
        //        orderBy: ascending ? (Func<IQueryable<ServiceProviderProject>, IOrderedQueryable<ServiceProviderProject>>)(q => q.OrderBy(p => p.Name)) 
        //                  : q => q.OrderByDescending(p => p.Name));
        //}

        //public async Task<IEnumerable<ServiceProviderProject>> GetFeaturedProjectsAsync(int count)
        //{
        //    return await _context.ServiceProviderProjects
        //        .Where(p => !string.IsNullOrEmpty(p.Image))
        //        .OrderByDescending(p => p.Id)
        //        .Take(count)
        //        .ToListAsync();
        //}
    }
}