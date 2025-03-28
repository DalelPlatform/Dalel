using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Driver;
using Models.Enums;
using Models.Restaurant;

namespace Dalel.Repository
{
    public class RestaurantRepository : BaseRepository<Models.Restaurant.Restaurant>
    {
        public RestaurantRepository(DelelContext dbContext) : base(dbContext)
        {

        }

        
        public IQueryable<Models.Restaurant.Restaurant> SearchRestaurants( // IQueryable<RestaurantDetailsViewModel>
          string city = null,
          string searchText = "",
         // int pageSize = 4,
         // int pageIndex = 1,
          //double? minRating = null,
          string sortBy = "Name",
          bool descending = false)
        {

            var builder = PredicateBuilder.New<Models.Restaurant.Restaurant>();

            var old = builder;

            //  Filter by city
            if (!string.IsNullOrEmpty(city))
                builder = builder.And(r => r.City.Contains(city));

            //  Search by restaurant Description
            if (!string.IsNullOrEmpty(searchText))
                builder = builder.And(r => r.Description.Contains(searchText));


            //if (minRating.HasValue)
            //    query = query.Where(r => r.AverageRating >= minRating.Value);

            builder = builder.And(r => r.IsDeleted == false);

            var count = base.GetList(builder).Count();

            var query = base.GetList(builder);

            query = SortRestaurants(query, sortBy, descending);

            return query;

            /*    
              var resultAfterPagination = base.Get(
                  filter: builder,
                  pageSize: pageSize,
                  pageNumber: pageIndex).Select(p => p.ToDetailsVModel()).ToList();

            return new PaginationViewModel<ProductDetailsViewModel>
              {
                  Data = resultAfterPagination,
                  PageNumber = pageNumber,
                  PageSize = pageSize,
                  Total = count
              }; */
        }
        public IQueryable<Models.Restaurant.Restaurant> SearchRestaurantsPaginated(
           int pageNumber, int pageSize,
           string city = null,
           string searchText = "",
        //   double? minRating = null,
           string sortBy = "Name",
           bool descending = false)
        {
            var query = SearchRestaurants(city, searchText,sortBy, descending);
            return query.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }

        private IQueryable<Models.Restaurant.Restaurant> SortRestaurants(IQueryable<Models.Restaurant.Restaurant> query, string sortBy, bool descending)
        {
            return sortBy.ToLower() switch
            {
                "city" => descending ? query.OrderByDescending(r => r.City) : query.OrderBy(r => r.City),
                "region" => descending ? query.OrderByDescending(r => r.Region) : query.OrderBy(r => r.Region),
                "modificationdate" => descending ? query.OrderByDescending(r => r.ModificationDate) : query.OrderBy(r => r.ModificationDate),
              //  "rating" => descending ? query.OrderByDescending(r => r.AverageRating) : query.OrderBy(r => r.AverageRating),
                "Id" => descending ? query.OrderByDescending(r => r.Id) : query.OrderBy(r => r.Id) // Default sort by Id
            };
        } 
     

        /*
        public IQueryable<Restaurant> GetRestaurantsByCity(string city)
        {z
            return _context.Restaurants
                .Where(r => r.City == city && !r.IsDeleted);
        }
        public IQueryable<Restaurant> GetVerifiedRestaurants()
        {
            return _context.Restaurants
                .Where(r => r.VerificationStatus == VerificationStatus.Confirmed && !r.IsDeleted);
        }
        public IQueryable<Restaurant> GetRestaurantWithDetails(int id)
        {
            return _context.Restaurants
                .Include(r => r.RestaurantOwner)
                .Include(r => r.RestaurantImages)
                .Include(r => r.RestaurantMenuItem)
                .Include(r => r.RestaurantOrders)
                .Include(r => r.RestaurantReservations)
                .Where(r => r.Id == id && !r.IsDeleted);
        }
        */
    }
}
