using Dalel.ViewModels;
using LinqKit;
using Models;
using Models.Enums;
using Models.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.Repository
{
    public class RestaurantMenuItemRepository : BaseRepository<RestaurantMenuItem>
    {
        public RestaurantMenuItemRepository(DelelContext dbContext) : base(dbContext)
        {

        }



        public PaginationViewModel<RestaurantMenuItemDetailsVM> SearchMenuItem( // IQueryable<RMenuItemVM>
        
         string searchText = "", //Name - Description ,
         FoodCategory ? category = null,
         AvaliabilityStatus status = AvaliabilityStatus.Available,
          int pageSize = 4,
          int pageIndex = 1,
         string sortBy = "Name",
         bool descending = false)
        {

            var builder = PredicateBuilder.New<RestaurantMenuItem>();

            var old = builder;

            #region filterd by 
            //  Filter by Name
            if (!string.IsNullOrEmpty(searchText))
                builder = builder.And(r => r.Name.Contains(searchText));

            //  Search by restaurant Description
            if (!string.IsNullOrEmpty(searchText))
                builder = builder.And(r => r.Description.Contains(searchText));

            //  Search by restaurant Category>>>  is this method will create in indivual method  ?
            if (category.HasValue)
                builder = builder.And(r => r.FoodCategory == category);

            //  Search by restaurant status>>>  is this method will create in indivual method  ?
            if (status != AvaliabilityStatus.Available)
                builder = builder.And(r => r.AvailabilityStatus == status);

            builder = builder.And(r => r.IsDeleted == false);

      

            #endregion




            var count = base.GetList(builder).Count();

            var query = base.GetList(builder);

            //query = SortRestaurants(query, sortBy, descending);



               
              var resultAfterPagination = base.Get(
                  filter: builder,
                  pageSize: pageSize,
                  pageNumber: pageIndex).Select(p => p.ToDetailsViewModel()).ToList();

            return new PaginationViewModel<RestaurantMenuItemDetailsVM>
              {
                  Data = resultAfterPagination,
                  PageNumber = pageIndex,
                  PageSize = pageSize,
                TotalCount = count
              }; 
        }






    }
}
