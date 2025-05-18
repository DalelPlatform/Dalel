using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dalel.ViewModels;
using LinqKit;
using Models;
using Models.Enums;
using Models.HomeChef;

namespace Dalel.Repository
{
    public class ReviewHomeChefOrderRepository : BaseRepository<ReviewHomeChefOrder>
    {

        public ReviewHomeChefOrderRepository(DelelContext dalel) : base(dalel) 
        {
        
        }

        public PaginationViewModel<ReviewHomeChefOrderDetailsVM> Search(
  string searchText = "",
    float? rating = null,
    DateTime? fromDate = null,
    DateTime? toDate = null,
    string? homeChefId = null,
    int? orderId = null,
    int pageSize = 10,
    int pageIndex = 1,
    string orderBy = "Id",
    bool isAscending = false)
        {
            var predicate = PredicateBuilder.New<ReviewHomeChefOrder>(true);

            // Search in comments
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                predicate = predicate.And(r =>
                    r.Comments.ToLower().Contains(searchText.ToLower()));
            }

            // Filter by HomeChefId
            if (!string.IsNullOrWhiteSpace(homeChefId))
            {
                predicate = predicate.And(r => r.HomeChefId == homeChefId);
            }

            // Filter by HomeChefOrderId
            if (orderId.HasValue)
            {
                predicate = predicate.And(r => r.HomeChefOrderId == orderId.Value);
            }

            // Filter by date range
            if (fromDate.HasValue)
            {
                predicate = predicate.And(r => r.ModificationDateTime >= fromDate.Value);
            }

            if (toDate.HasValue)
            {
                predicate = predicate.And(r => r.ModificationDateTime <= toDate.Value);
            }

            var query = base.GetList(predicate);
            var totalCount = query.Count();

            var result = Get(
                filter: predicate,
                orderBy: orderBy,
                isAscebding: isAscending,
                pageSize: pageSize,
                pageNumber: pageIndex
            );

            return new PaginationViewModel<ReviewHomeChefOrderDetailsVM>
            {
                Data = result.Select(b => b.ToDetailsViewModel()).ToList(),
                PageNumber = pageIndex,
                PageSize = pageSize,
                TotalCount = totalCount

            };
        }


        public ReviewHomeChefOrderDetailsVM ? GetReviewById(int id)
        {
            return base.GetList(r => r.Id == id)
                .Select(r => new ReviewHomeChefOrderDetailsVM()).FirstOrDefault();
        }

        public List<ReviewHomeChefOrderDetailsVM> GetAllReviews()
        {
            return base.GetList().Select(r => new ReviewHomeChefOrderDetailsVM
            {
                Comments = r.Comments,
                ModificationDateTime = r.ModificationDateTime,
                Rating = r.Rating
            }).ToList();
        }


        public List<ReviewHomeChefOrderDetailsVM> GetReviewsByOrderId(int id)
        {
            return base.GetList(r => r.HomeChefOrderId == id)
                .Select(r => new ReviewHomeChefOrderDetailsVM()).ToList();
        }

        public List<ReviewHomeChefOrderDetailsVM> GetReviewsByChefId(string id)
        {
            return base.GetList(r =>r. HomeChefId == id)
                .Select(r => new ReviewHomeChefOrderDetailsVM()).ToList();
        }


    }
}
