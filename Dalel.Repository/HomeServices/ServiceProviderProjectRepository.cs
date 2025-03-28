using Models.HomeService;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.Repository
{
    public class ServiceProviderProjectRepository : BaseRepository<ServiceProviderProject>
    {
        public ServiceProviderProjectRepository(DelelContext context) : base(context) { }

        public IQueryable<ServiceProviderProject> GetFeaturedProjects(int count = 3)
        {
            return GetList()
                   .OrderByDescending(x => x.ServiceProvider.StartProfisionalAt)
                   .Take(count);
        }
    }
}
