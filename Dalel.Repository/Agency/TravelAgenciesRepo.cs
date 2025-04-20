using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Agency;
using Models;
using Dalel.ViewModels.Agency.TravelAgencies;
using Dalel.ViewModels.Agency.Packagebooking;
using Dalel.ViewModels;
using LinqKit;

namespace Dalel.Repository.Agency
{
    public class TravelAgenciesRepo : BaseRepository<TravelAgencies>
    {
        public TravelAgenciesRepo(DelelContext _delelContext) :
            base(_delelContext)
        {

        }


        public PaginationViewModel<TravelAgenciesDetails> Search(
        string searchText = "",
        string BusinessCategory = "",
        string Address = "",
        string? owner = "",
        List<string>? Category =null ,

        int pageSize = 10,
        int pageIndex = 1,
        string OrderBy = "Id",
        bool IsAscending = false
       )
        {
            var predicate = PredicateBuilder.New<TravelAgencies>(true);
            var oldFilter = predicate;
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                predicate = predicate.And(b => 
                b.BusinessName.ToLower().Contains(searchText.ToLower())||
                b.Description.ToLower().Contains(searchText.ToLower()) 
                );
            }
            if (!string.IsNullOrWhiteSpace(Address))
            {
                predicate = predicate.And(b =>
                b.City.ToLower().Contains(Address.ToLower()) ||
                b.Address.ToLower().Contains(Address.ToLower()) ||
                b.Street.ToLower().Contains(Address.ToLower())
                );
            }
            if (!string.IsNullOrWhiteSpace(BusinessCategory))
            {
                predicate = predicate.And(b =>
                b.BusinessCategory.ToLower().Contains(BusinessCategory.ToLower()) 
               );
            }

            if (oldFilter == predicate)
            {
                predicate = null;
            }

            var query = base.GetList(predicate);

            var totalCount = query.Count();

            var result = Get(filter: predicate,
                orderBy: OrderBy,
                isAscebding: IsAscending,
                pageSize: pageSize, pageNumber: pageIndex);
           
            return new PaginationViewModel<TravelAgenciesDetails>
            {
                Data = result.Select(b => b.ToDetailsModels()).ToList(),
                PageNumber = pageIndex,
                PageSize = pageSize,
                TotalCount = totalCount
            };


        }





    }
    
}
