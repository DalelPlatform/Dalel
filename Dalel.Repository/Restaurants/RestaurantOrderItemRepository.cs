using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dalel.ViewModels.Restaurant;
using Microsoft.Identity.Client;
using Models;
using Models.Restaurant;

namespace Dalel.Repository
{
    public class RestaurantOrderItemRepository : BaseRepository<RestaurantOrderItem>
    {

        public RestaurantOrderItemRepository (DelelContext dalel) : base(dalel) 
        {
        } 



        //Get OrderItem By OrderId  

        public RestaurantOrderItemDetailsVM GetOrderItemByOrderId(int OrderId)
        {
            return base.GetList(orItem => orItem.RestaurantOrderId == OrderId).Select(or => new RestaurantOrderItemDetailsVM() ).FirstOrDefault() ;
        }
      


       // Get Total Price Of Order

        public float GetOrderTotalPrice(int OrderId)
        {
            return base.GetList(orItem => orItem.RestaurantOrderId == OrderId)
                .Sum(item => item.SupPrice * item.Quantity);
        }


        // Add Item to Order
        public void AddOrderItem(int orderItemId)
        {
            var RowOrderItem = base.GetList(orItem => orItem.RestaurantOrderId == orderItemId).FirstOrDefault();
            if(RowOrderItem != null)
            {
                Add(RowOrderItem);

            }
        }

        // Remove Item from Order
        public void RemoveOrderItem(int orderItemId)
        {
            var RowOrderItem = GetList(item => item.Id == orderItemId).FirstOrDefault();
            if (RowOrderItem != null)
            {
                Delete(RowOrderItem);
            }
        }





    }
}
