using Dalel.Repository;
using Models.HomeService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.Services.ServiceProvicerService
{
    public class ServiceProviderProjectsService
    {
        private readonly ServiceProviderProjectRepository _repository;
        public ServiceProviderProjectsService(ServiceProviderProjectRepository repository)
        {
            _repository = repository;
        }

        public async Task<IQueryable<ServiceProviderProject>> GetProjectsByProviderAsync(string providerId)
        {
            return (IQueryable<ServiceProviderProject>)await _repository.GetProjectsByProviderAsync(providerId);
        }

        public IQueryable<ServiceProviderProject> GetProjects(int pageSize, int pageNumber)
        {
            return (IQueryable<ServiceProviderProject>)_repository.Get(null, pageSize, pageNumber).ToList();
        }

        public ServiceProviderProject GetProjectById(int id)
        {
            return _repository.GetList(p => p.Id == id).FirstOrDefault();
        }

        public ServiceProviderProject CreateProject(ServiceProviderProject project, string imagePath = null)
        {
            if (!string.IsNullOrEmpty(imagePath))
            {
                project.Image = imagePath;
            }

            _repository.Add(project);
            return project;
        }

        public async Task UpdateProjectImageAsync(int id, string newImagePath)
        {
            await _repository.UpdateProjectImageAsync(id, newImagePath);
        }

        public void UpdateProject(ServiceProviderProject project)
        {
            _repository.Update(project);
        }

        public void DeleteProject(int id)
        {
            var project = GetProjectById(id);
            if (project != null)
            {
                _repository.Delete(project);
            }
        }
    }

}
