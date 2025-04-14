using Dalel.ViewModels;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Enums;
using Models.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dalel.Repository
{
    public class RestaurantRepository : BaseRepository<Restaurant>
    {
        public RestaurantRepository(DelelContext dbContext) : base(dbContext)
        {
        }

        public PaginationViewModel<RestaurantDetailsVM> SearchRestaurants(
            string searchText = "",
            string city = null,
            string region = null,
            VerificationStatus? verificationStatus = null,
            string sortBy = "Name",
            bool descending = false,
            int pageSize = 5,
            int pageIndex = 1)
        {
            var predicate = PredicateBuilder.New<Restaurant>(true);

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                predicate = predicate.And(r =>
                    r.Name.Contains(searchText) || r.Description.Contains(searchText));
            }

            if (!string.IsNullOrWhiteSpace(city))
            {
                predicate = predicate.And(r => r.City.Contains(city));
            }

            if (!string.IsNullOrWhiteSpace(region))
            {
                predicate = predicate.And(r => r.Region.Contains(region));
            }

            if (verificationStatus.HasValue)
            {
                predicate = predicate.And(r => r.VerificationStatus == verificationStatus.Value);
            }

            predicate = predicate.And(r => !r.IsDeleted);

            var totalCount = base.GetList(predicate).Count();
            var query = base.GetList(predicate);

            query = sortBy.ToLower() switch
            {
                "city" => descending ? query.OrderByDescending(r => r.City) : query.OrderBy(r => r.City),
                "region" => descending ? query.OrderByDescending(r => r.Region) : query.OrderBy(r => r.Region),
                "modificationdate" => descending ? query.OrderByDescending(r => r.ModificationDate) : query.OrderBy(r => r.ModificationDate),
                _ => descending ? query.OrderByDescending(r => r.Name) : query.OrderBy(r => r.Name)
            };

            var items = query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .Select(r => r.ToDetailsViewModel())
                .ToList();

            return new PaginationViewModel<RestaurantDetailsVM>
            {
                Data = items,
                PageNumber = pageIndex,
                PageSize = pageSize,
                TotalCount = totalCount
            };
        }

        public Restaurant GetById(int id)
        {
            return base.GetList(r => r.Id == id && !r.IsDeleted).FirstOrDefault();
        }
        public IQueryable<RestaurantDetailsVM> GetRestaurantsByVerificationStatus(VerificationStatus verificationStatus)
        {
            var restaurant = base.GetList(r => r.VerificationStatus == verificationStatus && !r.IsDeleted)
                .Select(r => r.ToDetailsViewModel());
            return restaurant.AsQueryable();
        }
    }
}
