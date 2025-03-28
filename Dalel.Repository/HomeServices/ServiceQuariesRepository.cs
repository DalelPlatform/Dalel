using Models.HomeService;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.Repository.HomeServices
{
    public class ServiceQuariesRepository : BaseRepository<ServiceQuaries>
    {
        public ServiceQuariesRepository(DelelContext context) : base(context) { }

        public IQueryable<ServiceQuaries> GetUnansweredQueries()
        {
            return GetList(x => string.IsNullOrEmpty(x.Answer))
                   .OrderBy(x => x.QuestionDate);
        }
    }
}
