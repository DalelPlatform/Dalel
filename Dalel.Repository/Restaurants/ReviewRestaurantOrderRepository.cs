using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Restaurant;

namespace Dalel.Repository
{
    public class ReviewRestaurantOrderRepository : BaseRepository<ReviewRestaurantOrder>
    {
        public ReviewRestaurantOrderRepository(DelelContext dalel) : base(dalel) 
        {
        
        }

         
    }

}
