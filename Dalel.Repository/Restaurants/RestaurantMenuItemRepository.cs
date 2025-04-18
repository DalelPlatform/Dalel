using Dalel.ViewModels;
using LinqKit;
using Models;
using Models.Enums;
using Models.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.Repository
{
    public class RestaurantMenuItemRepository : BaseRepository<RestaurantMenuItem>
    {
        public RestaurantMenuItemRepository(DelelContext dbContext) : base(dbContext)
        {

        }
        public  PaginationViewModel<RestaurantMenuItemDetailsVM> SearchMeals(
                string search = "",
                float? minPrice = null,
                float? maxPrice = null,
                AvaliabilityStatus? avaliabilityStatus = null,
                FoodCategory? foodCategory = null,
                SizeOfPiece? sizeOfPiece = null,
                double? duration = null,
                string sortBy = "Name",
                bool descending = false,
                int pageSize = 5,
                int pageIndex = 1)
        {
            var predicate = PredicateBuilder.New<RestaurantMenuItem>(true);

            if (!string.IsNullOrWhiteSpace(search))
            {
                predicate = predicate.And(m => m.Name.Contains(search));
                predicate = predicate.And(m => m.Description.Contains(search));
            }

            if (minPrice.HasValue)
                predicate = predicate.And(m => m.Price >= minPrice.Value);

            if (maxPrice.HasValue)
                predicate = predicate.And(m => m.Price <= maxPrice.Value);
            if (avaliabilityStatus.HasValue)
            {
                predicate = predicate.And(m => m.AvailabilityStatus == avaliabilityStatus.Value);
            }
            if (foodCategory.HasValue)
            {
                predicate = predicate.And(m => m.FoodCategory == foodCategory.Value);
            }
            if (sizeOfPiece.HasValue)
            {
                predicate = predicate.And(m => m.PieceSize == sizeOfPiece.Value);
            }

            Expression<Func<RestaurantMenuItem, object>> orderBy = sortBy.ToLower() switch
            {
                "price" => m => m.Price,
                "FoodCategory" => m => m.FoodCategory,
                "AvailabilityStatus" => m => m.AvailabilityStatus,
                "SizeOfPiece" => m => m.PieceSize,
                "Duration" => m => m.Duration,
                "Id" => m => m.Id,
                _ => m => m.Name
            };

            return  Search(predicate, orderBy, m => m.ToDetailsViewModel(), descending, pageSize, pageIndex);
        }
        public PaginationViewModel<RestaurantMenuItemDetailsVM> SearchMenuItem(
           string searchText = "",
           FoodCategory? category = null,
           AvaliabilityStatus status = AvaliabilityStatus.Available,
           float? minPrice = null,
           float? maxPrice = null,
           int pageSize = 4,
           int pageIndex = 1,
           string sortBy = "Name",
           bool descending = false)
        {
            var predicate = PredicateBuilder.New<RestaurantMenuItem>(true);

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                predicate = predicate.And(r =>
                    r.Name.Contains(searchText) || r.Description.Contains(searchText));
            }

            if (category.HasValue)
            {
                predicate = predicate.And(r => r.FoodCategory == category);
            }

            if (status != AvaliabilityStatus.Available)
            {
                predicate = predicate.And(r => r.AvailabilityStatus == status);
            }

            if (minPrice.HasValue)
            {
                predicate = predicate.And(r => r.Price >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                predicate = predicate.And(r => r.Price <= maxPrice.Value);
            }

            predicate = predicate.And(r => !r.IsDeleted);

            var query = base.GetList(predicate);

            var totalCount = query.Count();

            query = sortBy.ToLower() switch
            {
                "price" => descending ? query.OrderByDescending(r => r.Price) : query.OrderBy(r => r.Price),
                "category" => descending ? query.OrderByDescending(r => r.FoodCategory) : query.OrderBy(r => r.FoodCategory),
                _ => descending ? query.OrderByDescending(r => r.Name) : query.OrderBy(r => r.Name)
            };

            var items = query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .Select(p => p.ToDetailsViewModel())
                .ToList();

            return new PaginationViewModel<RestaurantMenuItemDetailsVM>
            {
                Data = items,
                PageNumber = pageIndex,
                PageSize = pageSize,
                TotalCount = totalCount
            };
        }

        public List<RestaurantMenuItemDetailsVM> GetMealsByRestaurantId(int restaurantId)
        {
            return base.GetList(m => m.RestaurantId == restaurantId && !m.IsDeleted)
                .Select(m => m.ToDetailsViewModel())
                .ToList();
        }

        public RestaurantMenuItem? GetMealById(int mealId)
        {
            return base.GetList(m => m.Id == mealId && !m.IsDeleted).FirstOrDefault();
        }
    }
}
