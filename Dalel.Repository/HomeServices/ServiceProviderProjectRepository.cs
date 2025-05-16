using Models.HomeService;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dalel.ViewModels;
using Models.Enums;

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
            return base.GetList(p => p.ServiceProviderId == serviceProviderId)
                .OrderByDescending(p => p.Id);
        }

        public void AddProject(ServiceProviderProject project, string imagePath = null)
        {
            if (!string.IsNullOrEmpty(imagePath))
            {
                project.ServiceProviderProjectImages = new List<ServiceProviderProjectImages>
                {
                    new ServiceProviderProjectImages { ImagePath = imagePath }
                };
            }
            base.Add(project);
            base.Save();

        }

        public void UpdateProject(ServiceProviderProject project, string imagePath)
        {
            if (!string.IsNullOrEmpty(imagePath))
            {
                UpdateProjectImage(project.Id, imagePath);
            }
            base.Update(project);
            base.Save();
        }

        public void UpdateProjectImage(int projectId, string newImagePath = null)
        {
            var project = base.Get(p => p.Id == projectId).FirstOrDefault();
            if (project != null)
            {
                var existingImages =  _context.ServiceProviderProjectImages
                .Where(i => i.ServiceProviderProjectId == projectId)
                .ToList();

                if (existingImages.Any())
                {
                    _context.ServiceProviderProjectImages.RemoveRange(existingImages);
                }

                project.ServiceProviderProjectImages = new List<ServiceProviderProjectImages>
            {
                new ServiceProviderProjectImages { ImagePath = newImagePath }
            };

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
    }
}