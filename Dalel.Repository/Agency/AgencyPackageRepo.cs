using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dalel.ViewModels;
using Dalel.ViewModels.Agency.AgencyPackage;
using Dalel.ViewModels.Agency.TravelAgencies;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Models;
using Models.Agency;
using Models.Enums;

namespace Dalel.Repository.Agency
{
    public class AgencyPackageRepo : BaseRepository<AgencyPackage>
    {
        //Get Packages by Agency ID

        public AgencyPackageRepo(DelelContext _delelContext) :
            base(_delelContext)
        {

        }
        public IQueryable<AgencyPackageDetails> GetAgencyPackage(int pckg_id)
        {
            return base.GetList(agenc => agenc.AgencyId == pckg_id)
                .Select(i => i.ToDetailsModels());


        }
        //Search Packages by Name
        public PaginationViewModel<AgencyPackageDetails> Search(
      string searchText = "",
      string Name = "",
      string Price = "",

      int pageSize = 10,
      int pageIndex = 1,
      string OrderBy = "Id",
      bool IsAscending = false
     )
        {
            var predicate = PredicateBuilder.New<AgencyPackage>(true);
            var oldFilter = predicate;
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                predicate = predicate.And(b =>
                b.Name.ToLower().Contains(searchText.ToLower()) ||
                 b.Description.ToLower().Contains(searchText.ToLower())
                );
            }
            if (!string.IsNullOrWhiteSpace(Price))
            {
                predicate = predicate.And(b =>
                b.Price == Price

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

            return new PaginationViewModel<AgencyPackageDetails>
            {
                Data = result.Select(b => b.ToDetailsModels()).ToList(),
                PageNumber = pageIndex,
                PageSize = pageSize,
                TotalCount = totalCount
            };


        }


        //Get Verified Packages
        public IQueryable<AgencyPackageDetails> GetVerifiedStatusPackages(VerificationStatus status)
        {
            return base.GetList(agenc => agenc.VerificationStatus ==
                status).Select(i => i.ToDetailsModels());
            ;

        }
        //Get Cheapest Packages
        public IQueryable<AgencyPackageDetails> GetCheapestPackages(int cheapPackg)
        {
            return base.GetList()
                .OrderBy(p => Convert.ToDecimal(p.Price))
                .Take(cheapPackg).Select(i => i.ToDetailsModels());
            ;

        }


    }
}