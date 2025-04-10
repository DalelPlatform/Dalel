using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dalel.ViewModels;
using Models;
using Models.Enums;
using Models.HomeChef;

namespace Dalel.Repository
{
    public class HomeChefOrderRepository : BaseRepository<HomeChefOrder> 
    {

        public HomeChefOrderRepository (DelelContext dalel) : base(dalel) 
        {
        
                
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
                .Select(orders=> new HomeChefOrderDetailsVM ()).ToList();
        }

        public List<HomeChefOrderDetailsVM> GetOrdersByCustomerId(string customerId)
        {
            return base.GetList(o => o.ClientId == customerId)
                .Select(orders => new HomeChefOrderDetailsVM()).ToList();
        }

        public List<HomeChefOrderDetailsVM> GetOrdersByStatus (OrderStatus status)
        {
            return base.GetList(o => o.OrderStatus == status)
                .Select(orders => new HomeChefOrderDetailsVM()).ToList();
        }

        public List<HomeChefOrderDetailsVM> GetOrdersByDate (DateTime date)
        {
            return base.GetList(o => o.OrderDate == date)
                .Select(orders => new HomeChefOrderDetailsVM()).ToList();
        }

       
    }
}
