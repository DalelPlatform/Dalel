using Models.Restaurant;

namespace Dalel.ViewModels
{
    public static class RestaurantMenuItemExt
    {
        public static RestaurantMenuItem ToModel(this AddRestaurantMenuItemVM menuItemVM)
        {
            return new RestaurantMenuItem
            {
                Name = menuItemVM.Name,
                Description = menuItemVM.Description,
                Price = menuItemVM.Price,
                DietaryTags = menuItemVM.DietaryTags,
                FoodCategory = menuItemVM.FoodCategory,
                PieceSize = menuItemVM.PieceSize,
                Duration = menuItemVM.Duration,
                RestaurantId = menuItemVM.RestaurantId ?? 0,
                RestaurantMenuItemImages = menuItemVM.Paths.Select(path => new RestaurantMenuItemImage() { Image = path }).ToList(),
                IsDeleted = false
            };
        }
        public static RestaurantMenuItemDetailsVM ToDetailsViewModel(this RestaurantMenuItem menuItem)
        {
            return new RestaurantMenuItemDetailsVM
            {
                Id = menuItem.Id,
                Name = menuItem.Name,
                Description = menuItem.Description,
                AvailabilityStatus = menuItem.AvailabilityStatus,
                DietaryTags = menuItem.DietaryTags,
                FoodCategory = menuItem.FoodCategory,
                Price = menuItem.Price,
                PieceSize = menuItem.PieceSize,
                Duration = menuItem.Duration,
                //VendorName = viewModel.Vendor.User.UserName ?? "Not Provided",
                RestaurantName = menuItem.Restaurant.Name ?? "Not Provided",
                //RestaurantType = menuItem.Restaurant.RestaurantType ,
                Images = menuItem.RestaurantMenuItemImages.Select(i => i.Image).ToList() ?? new List<string>()
            };
        }
        public static RestaurantMenuItem ToEditModel(this AddRestaurantMenuItemVM edit, RestaurantMenuItem old)
        {
            old.Name = string.IsNullOrEmpty(edit.Name) ? old.Name : edit.Name;
            old.Description = string.IsNullOrEmpty(edit.Description) ? old.Description : edit.Description;
            old.Price = edit.Price == 0 ? old.Price : edit.Price;
            old.DietaryTags = string.IsNullOrEmpty(edit.DietaryTags) ? old.DietaryTags : edit.DietaryTags;
            old.FoodCategory = edit.FoodCategory == old.FoodCategory ? old.FoodCategory : edit.FoodCategory;
            old.PieceSize = edit.PieceSize == old.PieceSize ? old.PieceSize : edit.PieceSize;
            old.Duration = edit.Duration == 0 ? old.Duration : edit.Duration;

            return old;
        }
    }
}
