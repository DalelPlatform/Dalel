using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dalel.ViewModels;
using Dalel.ViewModels.HomeChef.HomeChefDelivery;
using Models;
using Models.HomeChef;

namespace Dalel.Repository
{
    public class HomeChefDeliveryRepository : BaseRepository<HomeChefDelivery>
    {


        public HomeChefDeliveryRepository (DelelContext dalel) : base (dalel)
        {
        

        }
       
        public HomeChefDeliveryDetailsVM GetDeliveryById (int id)
        {
            
                return base.GetList(delivery => delivery.Id == id).Select(d => new HomeChefDeliveryDetailsVM()).FirstOrDefault();
          
        }

        public List<HomeChefDeliveryDetailsVM> GetAllDeliveries()
        {
            return base.GetList().Select(d => new HomeChefDeliveryDetailsVM()
            {
               PlatformLogistics = d.PlatformLogistics,
               DeliveryStatus = d.DeliveryStatus,
               SelfDelivery = d.SelfDelivery

            }).ToList();
        }

        public List<HomeChefDeliveryDetailsVM> GetDeliveriesByDate(DateTime date)
        {
            return base.GetList(delivery => delivery.DateTime == date).Select(d => new HomeChefDeliveryDetailsVM()).ToList();
        }




    }
}
