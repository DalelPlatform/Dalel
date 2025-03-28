using Dalel.ViewModels;
using LinqKit;
using Models;
using Models.Enums;
using Models.Property;
using Models.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.Repository
{
    class PropertiesRepository : BaseRepository<Properties>
    {
        public PropertiesRepository(DelelContext dbContext) : base(dbContext)
        {

        }

        public PaginationViewModel<PropertiesDetailsVM> SearchProperties( 
          string city = null,
          string address = null,
          string searchText = "",
          int pageSize = 4,
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

            builder = builder.And(r => r.IsDeleted == false);

            var count = base.GetList(builder).Count();

            var query = base.GetList(builder);
             
              var resultAfterPagination = base.Get(
                  filter: builder,
                  pageSize: pageSize,
                  pageNumber: pageIndex).Select(p => p.ToDetailsViewModel()).ToList();

            return new PaginationViewModel<PropertiesDetailsVM>
              {
                  Data = resultAfterPagination,
                  PageNumber = pageIndex,
                  PageSize = pageSize,
                  TotalCount = count
              }; 
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
    }
}
