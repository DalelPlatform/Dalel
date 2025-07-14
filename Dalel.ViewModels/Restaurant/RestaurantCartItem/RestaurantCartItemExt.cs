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
                MenuItemPrice = item.RestaurantMenuItem?.Price,
                RestaurantId = item.RestaurantMenuItem.RestaurantId

            };
        }

        public static RestaurantCartItem ToEditModel(this AddRestaurantCartItemVM edit, RestaurantCartItem old)
        {
            if (edit.SupPrice > 0)
                old.SupPrice = edit.SupPrice;

            if (edit.Quantity > 0)
                old.Quantity = edit.Quantity;

            if (!string.IsNullOrWhiteSpace(edit.ClientId))
                old.ClientId = edit.ClientId;

            if (edit.RestaurantMenuItemId > 0)
                old.RestaurantMenuItemId = edit.RestaurantMenuItemId;

            return old;
        }

    }

}
