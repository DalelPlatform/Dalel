using Models;
using Models.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.Repository
{
    public class RestaurantMenuItemRepository : BaseRepository<RestaurantMenuItem>
    {
        public RestaurantMenuItemRepository(DelelContext dbContext) : base(dbContext)
        {

        }



    }
}
