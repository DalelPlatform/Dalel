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

        public async Task<IQueryable<ServiceQuaries>> GetQueriesByCategoryAsync(int categoryId)
        {

            var queries = await base.GetList(q => q.CategoryServicesId == categoryId)
                          .OrderByDescending(q => q.QuestionDate)
                          .ToListAsync();

            return (IQueryable<ServiceQuaries>)queries;
        }

        public async Task<IQueryable<ServiceQuaries>> GetQueriesByClientAsync(string clientId)
        {
            return (IQueryable<ServiceQuaries>)await base.GetList(q => q.ClientId == clientId)
                          .OrderByDescending(q => q.QuestionDate)
                          .ToListAsync();

        }

        public async Task<IQueryable<ServiceQuaries>> GetQueriesByProviderAsync(string providerId)
        {

            return (IQueryable<ServiceQuaries>)await _context.ServiceQuaries
                         .Where(q => q.ServiceProviderId == providerId)
                         .OrderByDescending(q => q.QuestionDate)
                         .ToListAsync();
        }

        public async Task<bool> AnswerQueryAsync(int queryId, string answer)
        {
            var query = await base.GetList(q => q.Id == queryId).FirstOrDefaultAsync();
            if (query != null)
            {
                query.Answer = answer;
                query.AnswerDate = DateTime.Now;
                return true;
            }
            return false;
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
