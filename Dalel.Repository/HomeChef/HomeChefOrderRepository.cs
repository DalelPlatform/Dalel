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
using Models.WeddingPlaces.Enums;

namespace Dalel.Repository
{
    public class HomeChefOrderRepository : BaseRepository<HomeChefOrder>
    {

        public HomeChefOrderRepository(DelelContext dalel) : base(dalel)
        {


        }

        public PaginationViewModel<HomeChefOrderDetailsVM> Search(
         string searchText = "",
    string? customerId = "",
    OrderStatus? status = null,
    DateTime? fromDate = null,
    DateTime? toDate = null,
    int pageSize = 10,
    int pageIndex = 1,
    string orderBy = "Id",
    bool IsAscending = false)
        {
            var predicate = PredicateBuilder.New<HomeChefOrder>(true);

            // Search text filter
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                predicate = predicate.And(b =>
                    (!string.IsNullOrEmpty(b.Client.User.FirstName) ? b.Client.User.FirstName : "").ToLower().Contains(searchText.ToLower()) ||
                    (!string.IsNullOrEmpty(b.Client.User.LastName) ? b.Client.User.LastName : "").ToLower().Contains(searchText.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(customerId))
            {
                predicate = predicate.And(o => o.ClientId == customerId);
            }

            if (status.HasValue)
            {
                predicate = predicate.And(o => o.OrderStatus == status.Value);
            }

            if (fromDate.HasValue)
            {
                predicate = predicate.And(o => o.OrderDate >= fromDate.Value);
            }

            if (toDate.HasValue)
            {
                predicate = predicate.And(o => o.OrderDate <= toDate.Value);
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

            return new PaginationViewModel<HomeChefOrderDetailsVM>
            {
                Data = result.Select(b => b.ToDetailsViewModel()).ToList(),
                PageNumber = pageIndex,
                PageSize = pageSize,
                TotalCount = totalCount

            };
        }




        public HomeChefOrderDetailsVM GetOrderById(int id)
        {
            return base.GetList(o => o.Id == id).Select(o => new HomeChefOrderDetailsVM()).FirstOrDefault();
        }

        public List<HomeChefOrderDetailsVM> GetAllOrders()
        {
            return base.GetList().Select(o => new HomeChefOrderDetailsVM
            {
                OrderDate = o.OrderDate,
                OrderStatus = o.OrderStatus,
                TotalPrice = o.TotalPrice

            }).ToList();
        }


        public List<HomeChefOrderDetailsVM> GetOrdersByChefId(string chefId)
        {
            return base.GetList(o => o.HomeChefId == chefId)
                .Select(orders => new HomeChefOrderDetailsVM()).ToList();
        }

        public List<HomeChefOrderDetailsVM> GetOrdersByCustomerId(string customerId)
        {
            return base.GetList(o => o.ClientId == customerId)
                .Select(orders => new HomeChefOrderDetailsVM()).ToList();
        }

        public List<HomeChefOrderDetailsVM> GetOrdersByStatus(OrderStatus status)
        {
            return base.GetList(o => o.OrderStatus == status)
                .Select(orders => new HomeChefOrderDetailsVM()).ToList();
        }

        public List<HomeChefOrderDetailsVM> GetOrdersByDate(DateTime date)
        {
            return base.GetList(o => o.OrderDate == date)
                .Select(orders => new HomeChefOrderDetailsVM()).ToList();
        }


    }
}
