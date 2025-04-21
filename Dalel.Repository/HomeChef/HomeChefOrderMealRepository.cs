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
    public class HomeChefOrderMealRepository : BaseRepository<HomeChefOrderMeal>
    {
        public HomeChefOrderMealRepository(DelelContext dalel ): base(dalel)
        {
            
        }


        public PaginationViewModel<HomeChefOrderMealDetailsVM> Search(
        string searchText = "",
        string? customerId = "",
        int pageSize = 10,
        int pageIndex = 1,
        string orderBy = "Id",
        bool IsAscending = false)
        {
            var predicate = PredicateBuilder.New<HomeChefOrderMeal>(true);

            // Search text filter
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                predicate = predicate.And(b =>
                    (!string.IsNullOrEmpty(b.HomeChefOrder.Client.User.FirstName) ? b.HomeChefOrder.Client.User.FirstName : "").ToLower().Contains(searchText.ToLower()) ||
                    (!string.IsNullOrEmpty(b.HomeChefOrder.Client.User.LastName) ? b.HomeChefOrder.Client.User.LastName : "").ToLower().Contains(searchText.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(customerId))
            {
                predicate = predicate.And(o => o.HomeChefOrder.ClientId == customerId);
            }


            var query = base.GetList(predicate);
            var totalCount = query.Count();

            var result = Get(
                filter: predicate,
                orderBy: orderBy,
                isAscebding: IsAscending,
                pageSize: pageSize,
                pageNumber: pageIndex
            );

            return new PaginationViewModel<HomeChefOrderMealDetailsVM>
            {
                Data = result.Select(b => b.ToDetailsViewModel()).ToList(),
                PageNumber = pageIndex,
                PageSize = pageSize,
                TotalCount = totalCount

            };
        }


        public HomeChefOrderMealDetailsVM ? GetOrderMealById(int id)

        {
                return base.GetList(m => m.Id == id)
                .Select(m => new HomeChefOrderMealDetailsVM()).FirstOrDefault();
        }


        public List<HomeChefOrderMealDetailsVM> GetMealsByOrderId(int id)
        {
            return base.GetList(o => o.HomeChefOrdersId == id)
                .Select(meals => new HomeChefOrderMealDetailsVM()).ToList();
        }


        public List<HomeChefOrderMealDetailsVM> GetMealsByMealId(int id)
        {
            return base.GetList(m => m.HomeChefMealsId == id)
                .Select(meals => new HomeChefOrderMealDetailsVM() ).ToList();
        }



    }
}
