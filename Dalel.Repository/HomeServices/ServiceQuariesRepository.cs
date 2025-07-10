using Models.HomeService;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Dalel.Repository.HomeServices
{
    public class ServiceQuariesRepository : BaseRepository<ServiceQuaries>
    {
        private readonly DelelContext _context;

        public ServiceQuariesRepository(DelelContext context) : base(context)
        {
        }

        public IQueryable<ServiceQuaries> GetQueriesByCategory(int categoryId)
        {

            return base.GetList(q => q.CategoryServicesId == categoryId)
                          .OrderByDescending(q => q.CommentDate);

        }

        public IQueryable<ServiceQuaries> GetQueriesByClient(string clientId)
        {
            return base.GetList(q => q.ClientId == clientId)
                          .OrderByDescending(q => q.CommentDate);

        }

        public IQueryable<ServiceQuaries> GetQueriesByProvider(string providerId)
        {

            return base.GetList(q => q.ServiceProviderId == providerId)
                         .OrderByDescending(q => q.CommentDate);
        }


        public ServiceQuaries GetQueryById(int id)
        {
            return base.Get(q => q.Id == id).FirstOrDefault();
        }



        //public async Task<PagedResult<ServiceQuaries>> FilterQueriesAsync(
        //    int? categoryId = null,
        //    string providerId = null,
        //    string clientId = null,
        //    bool? answered = null,
        //    DateTime? fromDate = null,
        //    DateTime? toDate = null,
        //    string searchTerm = null,
        //    int pageNumber = 1,
        //    int pageSize = 10,
        //    string sortBy = "QuestionDate",
        //    bool ascending = false)
        //{
        //    var query = _context.ServiceQuaries
        //        .Include(q => q.Client)
        //        .Include(q => q.ServiceProvider)
        //        .Include(q => q.CategoryServices)
        //        .AsQueryable();

        //    if (categoryId.HasValue)
        //    {
        //        query = query.Where(q => q.CategoryServicesId == categoryId.Value);
        //    }

        //    if (!string.IsNullOrEmpty(providerId))
        //    {
        //        query = query.Where(q => q.ServiceProviderId == providerId);
        //    }

        //    if (!string.IsNullOrEmpty(clientId))
        //    {
        //        query = query.Where(q => q.ClientId == clientId);
        //    }

        //    if (answered.HasValue)
        //    {
        //        query = answered.Value
        //            ? query.Where(q => !string.IsNullOrEmpty(q.Answer))
        //            : query.Where(q => string.IsNullOrEmpty(q.Answer));
        //    }

        //    if (fromDate.HasValue)
        //    {
        //        query = query.Where(q => q.QuestionDate >= fromDate.Value);
        //    }

        //    if (toDate.HasValue)
        //    {
        //        query = query.Where(q => q.QuestionDate <= toDate.Value);
        //    }

        //    if (!string.IsNullOrEmpty(searchTerm))
        //    {
        //        query = query.Where(q => q.Question.Contains(searchTerm) ||
        //                             (q.Answer != null && q.Answer.Contains(searchTerm)));
        //    }

        //    // Sorting
        //    query = sortBy switch
        //    {
        //        "QuestionDate" => ascending
        //            ? query.OrderBy(q => q.QuestionDate)
        //            : query.OrderByDescending(q => q.QuestionDate),
        //        "AnswerDate" => ascending
        //            ? query.OrderBy(q => q.AnswerDate)
        //            : query.OrderByDescending(q => q.AnswerDate),
        //        "Category" => ascending
        //            ? query.OrderBy(q => q.CategoryServices.Name)
        //            : query.OrderByDescending(q => q.CategoryServices.Name),
        //        _ => query.OrderByDescending(q => q.QuestionDate)
        //    };

        //    var result = new PagedResult<ServiceQuaries>
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
    }
}
