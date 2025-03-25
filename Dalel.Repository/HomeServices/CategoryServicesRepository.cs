using Models.HomeService;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.Repository
{
    public class CategoryServicesRepository : BaseRepository<CategoryServices>
    {
        public CategoryServicesRepository(DelelContext context) : base(context) { }

        public IQueryable<CategoryServices> GetPopularCategories(int count = 5)
        {
            return GetList()
                .OrderByDescending(c => c.ServiceProviders.Count)
                .Take(count);
        }
    }
}
