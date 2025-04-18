using Dalel.ViewModels;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Enums;
using Models.Restaurant;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

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
            string street = null,
            string address = null,
            int NumberOfRooms = 0,
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
            if (!string.IsNullOrWhiteSpace(street))
            {
                predicate = predicate.And(r => r.Street.Contains(street));
            }
            if (!string.IsNullOrWhiteSpace(address))
            {
                predicate = predicate.And(r => r.Address.Contains(address));
            }

            if (verificationStatus.HasValue)
            {
                predicate = predicate.And(r => r.VerificationStatus == verificationStatus.Value);
            }
            if (NumberOfRooms > 0)
            {
                predicate = predicate.And(r => r.NumberOfRooms == NumberOfRooms);
            }

            predicate = predicate.And(r => !r.IsDeleted);

            Expression<Func<Restaurant, object>> orderBy = sortBy.ToLower() switch
            {
                "id" => m => m.Id,
                "NumberOfRooms" => m => m.NumberOfRooms,
                "Region" => m => m.Region,
                _ => m => m.Name
            };

            return  Search(predicate, orderBy, m => m.ToDetailsViewModel(), descending, pageSize, pageIndex);
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
        public RestaurantDetailsVM GetRestaurantByOwnerId(string ownerId)
        {
            return base.GetList()
        .FirstOrDefault(r => r.OwnerId == ownerId && !r.IsDeleted)
        ?.ToDetailsViewModel();
        }
    }
}
