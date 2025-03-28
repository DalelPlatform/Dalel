using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Models;
using Models.Enums;
using Models.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.Repository
{
    public class PaymentRestaurantOrderReopsitory : BaseRepository<PaymentRestaurantOrder>
    {
        public PaymentRestaurantOrderReopsitory(DelelContext dbcontext) 
            : base(dbcontext)
        {

        }


      //  public IQueryable<PaymentRestaurantOrder> 
        public IQueryable<PaymentRestaurantOrder> GetPaymentRestaurantOrderByID(int id)
        {
            return base.GetList(p => p.Id == id);
        }

        public IQueryable<PaymentRestaurantOrder> GetPaymentByStatus(PaymentStatus status)
        {
            return base.GetList(p => p.PaymentStatus == status);
        }

    }
}
