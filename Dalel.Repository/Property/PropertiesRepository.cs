using Dalel.ViewModels;
using LinqKit;
using Models;
using Models.Enums;
using Models.Property;
using Models.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.Repository
{
    public class PropertiesRepository : BaseRepository<Properties>
    {
        public PropertiesRepository(DelelContext dbContext) : base(dbContext)
        {

        }

        public PaginationViewModel<PropertiesDetailsVM> SearchProperties(
             string searchText = "",
             string city = null,
             string region = null,
             string street = null,
             string address = null,
             int NumberOfRooms = 0,
             int BuildingNo = 0,
             int FloorNo = 0,
             VerificationStatus? verificationStatus = null,
             string sortBy = "id",
             bool descending = false,
             int pageSize = 5,
             int pageIndex = 1)
        {

            var builder = PredicateBuilder.New<Properties>();

            var old = builder;

            if (!string.IsNullOrEmpty(city))
                builder = builder.And(r => r.City.Contains(city));

            if (!string.IsNullOrEmpty(address))
                builder = builder.And(r => r.Address.Contains(address));

            if (!string.IsNullOrEmpty(searchText))
                builder = builder.And(r => r.Description.Contains(searchText));

            if (!string.IsNullOrEmpty(region))
                builder = builder.And(r => r.Region.Contains(region));

            if (!string.IsNullOrEmpty(street))
                builder = builder.And(r => r.Street.Contains(street));

            if (NumberOfRooms > 0)
                builder = builder.And(r => r.NumberOfRooms == NumberOfRooms);

            if (BuildingNo > 0)
                builder = builder.And(r => r.BuildingNo == BuildingNo);

            if (FloorNo > 0)
                builder = builder.And(r => r.FloorNo == FloorNo);

            if (verificationStatus.HasValue)
                builder = builder.And(r => r.VerificationStatus == verificationStatus.Value);

            builder = builder.And(r => r.IsDeleted == false);


            Expression<Func<Properties, object>> orderBy = sortBy.ToLower() switch
            {
                "NumberOfRooms" => m => m.NumberOfRooms,
                "Region" => m => m.Region,
                "Street" => m => m.Street,
                "Address" => m => m.Address,
                _ => m => m.Id
            };

            return Search(builder, orderBy, m => m.ToDetailsViewModel(), descending, pageSize, pageIndex);
        }
        public PropertiesDetailsVM GetPropertyById(int propertyId)
        {
            return GetList(p => p.Id == propertyId && !p.IsDeleted).Select(p => p.ToDetailsViewModel()).FirstOrDefault();
        }

        public IQueryable<PropertiesDetailsVM> GetPropertiesByOwner(string ownerId)
        {
            return GetList(p => p.OwnerId == ownerId && !p.IsDeleted).Select(p => p.ToDetailsViewModel());
        }
        public IQueryable<PropertiesDetailsVM> GetPropertiesForRent()
        {
            return GetList(p => p.IsForRent && !p.IsDeleted).Select(p => p.ToDetailsViewModel());
        }

        public IQueryable<PropertiesDetailsVM> GetVerifiedProperties()
        {
            return GetList(p => p.VerificationStatus == VerificationStatus.Confirmed && !p.IsDeleted).Select(p => p.ToDetailsViewModel());
        }

        public void SoftDeleteProperty(int propertyId)
        {
            var property = GetList(p => p.Id == propertyId).FirstOrDefault();
            if (property != null)
            {
                property.IsDeleted = true;
                Update(property);
            }
        }

        public void UpdateVerificationStatus(int propertyId, VerificationStatus status)
        {
            var property = GetList(p => p.Id == propertyId).FirstOrDefault();
            if (property != null)
            {
                property.VerificationStatus = status;
                Update(property);
            }
        }

        public IQueryable<PropertiesDetailsVM> GetPendingProperties()
        {
            return GetList(p => p.VerificationStatus == VerificationStatus.Pending)
                .Select(p => p.ToDetailsViewModel());

        }
      
    }
}
