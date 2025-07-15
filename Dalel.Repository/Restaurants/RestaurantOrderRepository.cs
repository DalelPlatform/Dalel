using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Enums;
using Models.Restaurant;

namespace Dalel.Repository
{
    public class RestaurantOrderRepository : BaseRepository<RestaurantOrder>

    {
        public RestaurantOrderRepository(DelelContext dalel) : base(dalel)
        {

        }


        //public IQueryable<RestaurantOrder> GetOrdersByRestaurant(int restaurantId)
        //{
        //    return base.GetList(or => or.RestaurantId == restaurantId);
        //}


        public IQueryable<RestaurantOrder> GetOrdersByClient(string clientId)
        {
            return base.GetList(or => or.ClientId == clientId);
        }

        // 
        public RestaurantOrder GetOrderDetails(int orderId)
        {
            return base.GetList(or => or.Id == orderId).FirstOrDefault();
        }


        public void UpdateOrderStatus(int orderId, OrderStatus newStatus)
        {
            var order = GetList(or => or.Id == orderId).FirstOrDefault();
            if (order != null)
            {
                order.OrderStatus = newStatus;
                Update(order);
            }

        }


    }
    }
