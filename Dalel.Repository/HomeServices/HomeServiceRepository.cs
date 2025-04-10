using Models;
using Models.HomeService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.Repository.HomeServices
{
    public class HomeServiceRepository
    {
        private readonly DelelContext _context;

        public HomeServiceRepository(DelelContext context)
        {
            _context = context;
        }

        // CategoryServices
        public IQueryable<CategoryServices> GetCategories()
        {
            return _context.CategoryServices.AsQueryable();
        }

        public CategoryServices GetCategoryById(int id)
        {
            return _context.CategoryServices.FirstOrDefault(c => c.Id == id);
        }

        public void AddCategory(CategoryServices category)
        {
            _context.CategoryServices.Add(category);
            _context.SaveChanges();
        }

        public void UpdateCategory(CategoryServices category)
        {
            _context.CategoryServices.Update(category);
            _context.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            var category = GetCategoryById(id);
            if (category != null)
            {
                _context.CategoryServices.Remove(category);
                _context.SaveChanges();
            }
        }

        // ServiceProviderProjects
        public IQueryable<ServiceProviderProject> GetProjects(string serviceProviderId)
        {
            return _context.ServiceProviderProjects.Where(p => p.ServiceProviderId == serviceProviderId);
        }

        public ServiceProviderProject GetProjectById(int id)
        {
            return _context.ServiceProviderProjects.FirstOrDefault(p => p.Id == id);
        }

        public void AddProject(ServiceProviderProject project)
        {
            _context.ServiceProviderProjects.Add(project);
            _context.SaveChanges();
        }

        public void UpdateProject(ServiceProviderProject project)
        {
            _context.ServiceProviderProjects.Update(project);
            _context.SaveChanges();
        }

        public void DeleteProject(int id)
        {
            var project = GetProjectById(id);
            if (project != null)
            {
                _context.ServiceProviderProjects.Remove(project);
                _context.SaveChanges();
            }
        }

        // ServiceProviderPropsal
        public void AddProposal(ServiceProviderPropsal proposal)
        {
            _context.ServiceProviderPropsals.Add(proposal);
            _context.SaveChanges();
        }

        // ServiceQuaries
        public IQueryable<ServiceQuaries> GetQueries(string serviceProviderId)
        {
            return _context.ServiceQuaries.Where(q => q.ServiceProviderId == serviceProviderId);
        }

        public ServiceQuaries GetQueryById(int id)
        {
            return _context.ServiceQuaries.FirstOrDefault(q => q.Id == id);
        }

        public void UpdateQuery(ServiceQuaries query)
        {
            _context.ServiceQuaries.Update(query);
            _context.SaveChanges();
        }
    }
}
