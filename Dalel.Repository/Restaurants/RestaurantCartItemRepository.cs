using Dalel.ViewModels;
using Models;
using Models.Restaurant;

namespace Dalel.Repository
{
    public class RestaurantCartItemRepository : BaseRepository<RestaurantCartItem>
    {

        public  RestaurantCartItemRepository(DelelContext dbContext) : base(dbContext)
        {
        }

        public List<RestauranCartItemDetailsVM> GetCartItemsByClientId(string clientId)
        {
            return base.GetList(m => m.ClientId == clientId && !m.IsDeleted)
                .Select(m => m.ToDetailsVM())
                .ToList();
        }





    }
}
