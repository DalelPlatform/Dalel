using Models.Restaurant;

namespace Dalel.ViewModels
{
    public static class RestaurantCartItemExt
    {
        public static RestaurantCartItem ToModel(this AddRestaurantCartItemVM vm)
        {
            return new RestaurantCartItem
            {
                SupPrice = vm.SupPrice,
                Quantity = vm.Quantity,
                ClientId = vm.ClientId,
                RestaurantMenuItemId = vm.RestaurantMenuItemId
            };
        }

        public static RestauranCartItemDetailsVM ToDetailsVM(this RestaurantCartItem item)
        {
            return new RestauranCartItemDetailsVM
            {
                Id = item.Id,
                SupPrice = item.SupPrice,
                Quantity = item.Quantity,
                ClientId = item.ClientId,
                ClientName = item.Client?.User.FirstName,
                RestaurantMenuItemId = item.RestaurantMenuItemId,
                MenuItemName = item.RestaurantMenuItem?.Name,
                MenuItemPrice = item.RestaurantMenuItem?.Price
            };
        }

        public static RestaurantCartItem ToEditModel(this AddRestaurantCartItemVM edit, RestaurantCartItem old)
        {
            old.SupPrice = edit.SupPrice == 0 ? old.SupPrice : edit.SupPrice;
            old.Quantity = edit.Quantity == 0 ? old.Quantity : edit.Quantity;
            old.ClientId = string.IsNullOrEmpty(edit.ClientId) ? old.ClientId : edit.ClientId;
            old.RestaurantMenuItemId = edit.RestaurantMenuItemId == 0 ? old.RestaurantMenuItemId : edit.RestaurantMenuItemId;
            return old;
        }
    }

}
