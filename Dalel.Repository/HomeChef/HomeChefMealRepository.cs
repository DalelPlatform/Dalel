using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dalel.ViewModels;
using Dalel.ViewModels.Agency.TravelAgencies;
using LinqKit;
using Models;
using Models.Agency;
using Models.Enums;
using Models.HomeChef;

namespace Dalel.Repository
{
    public class HomeChefMealRepository : BaseRepository<HomeChefMeal>
    {
        public HomeChefMealRepository(DelelContext dalelContext) : base(dalelContext) 
        {

        }



        public PaginationViewModel<HomeChefMealDetailsVM> Search(
        string searchText = "",
        bool? AvailabilityStatus = true, // default = true
        string? owner = "",
        FoodCategory? foodCategory = null, // now filtering by enum
        decimal? Price = null,
        int pageSize = 10,
        int pageIndex = 1,
        string OrderBy = "Id",
        bool IsAscending = false)
        {
            var predicate = PredicateBuilder.New<HomeChefMeal>(true);

            // Search text filter
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                predicate = predicate.And(b =>
                    b.DishName.ToLower().Contains(searchText.ToLower()) ||
                    b.Description.ToLower().Contains(searchText.ToLower()) ||
                    b.DietaryTags.ToLower().Contains(searchText.ToLower()));
            }

            // Owner filter
            if (!string.IsNullOrWhiteSpace(owner))
            {
                predicate = predicate.And(b => b.HomeChefId.ToLower().Contains(owner.ToLower()));
            }

            // AvailabilityStatus filter
            if (AvailabilityStatus.HasValue)
            {
                predicate = predicate.And(b => b.AvailabilityStatus == AvailabilityStatus.Value);
            }

            // Food category filter
            if (foodCategory.HasValue)
            {
                predicate = predicate.And(b => b.FoodCategory == foodCategory.Value);
            }

            // Price filter
            if (Price.HasValue)
            {
                predicate = predicate.And(b => b.Price <= Price.Value);
            }

            var query = base.GetList(predicate);
            var totalCount = query.Count();

            var result = Get(
                filter: predicate,
                orderBy: OrderBy,
                isAscebding: IsAscending,
                pageSize: pageSize,
                pageNumber: pageIndex
            );

            return new PaginationViewModel<HomeChefMealDetailsVM>
            {
                Data = result.Select(b => b.ToDetailsViewModel()).ToList(),
                PageNumber = pageIndex,
                PageSize = pageSize,
                TotalCount = totalCount
                
            };
        }




        public HomeChefMealDetailsVM GetMealById(int id)
        {

            return base.GetList(meal => meal.Id == id).Select(m => new HomeChefMealDetailsVM()).FirstOrDefault();

        }

        public List<HomeChefMealDetailsVM> GetAllMeals()
        {
            return base.GetList().Select(m => new HomeChefMealDetailsVM()
            {
                DishName = m.DishName,
                Description = m.Description,
                DietaryTags = m.DietaryTags,
                Duration = m.Duration,
                AvailabilityStatus = m.AvailabilityStatus,
                FoodCategory = m.FoodCategory,
                PieceSize = m.PieceSize,
                Price = m.Price,
                Images = m.HomeChefMealImages.Select(image =>  image.Image).ToList()


            }).ToList();
        }

     

        public List<HomeChefMealDetailsVM> GetMealsByChefId (string chefId)
        {
            return base.GetList(meals => meals.HomeChefId == chefId)
                .Select(m => new HomeChefMealDetailsVM()).ToList() ;
        }

        public List<HomeChefMealDetailsVM> GetMealsByCategory(FoodCategory category)
        {
            return base.GetList(meals => meals.FoodCategory == category)
                .Select(m => new HomeChefMealDetailsVM()).ToList();
        }

        public List<HomeChefMealDetailsVM> SearchMeals(string keyword)
        {
            return base.GetList(meals => meals.DishName.Contains(keyword) || meals.Description.Contains(keyword))
                .Select(m => new HomeChefMealDetailsVM()).ToList();
        }

        public List<HomeChefMealDetailsVM> GetAvailableMeals(bool status)
        {
            return base.GetList(meals => meals.AvailabilityStatus == status)
                .Select(m => new HomeChefMealDetailsVM()).ToList();
        }

    }
}
