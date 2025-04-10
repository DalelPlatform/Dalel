using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dalel.ViewModels.HomeChef.HomeChefMeal;
using Models.HomeChef;

namespace Dalel.ViewModels
{
    public static class HomeChefMealExt
    {
        public static HomeChefMeal ToModel (this AddHomeChefMealVM addHomeChefMealVM)
        {
            return new HomeChefMeal
            {
                DishName = addHomeChefMealVM.DishName,
                HomeChefId = addHomeChefMealVM.HomeChefId,
                Description = addHomeChefMealVM.Description,
                Price = addHomeChefMealVM.Price,
                AvailabilityStatus = addHomeChefMealVM.AvailabilityStatus,
                DietaryTags = addHomeChefMealVM.DietaryTags,
                FoodCategory = addHomeChefMealVM.FoodCategory,
                PieceSize = addHomeChefMealVM.PieceSize,
                Duration = addHomeChefMealVM.Duration,
                HomeChefMealImages = addHomeChefMealVM.Paths.Select(path => new HomeChefMealImage() { Image = path }).ToList(),
                IsDeleted = false
                
            };
        }


        public static HomeChefMealDetailsVM ToDetailsViewModel(this HomeChefMeal homeChefMeal)
        {
            return new HomeChefMealDetailsVM
            {
                DishName = homeChefMeal.DishName,
                Description = homeChefMeal.Description, 
                Price = homeChefMeal.Price,
                DietaryTags = homeChefMeal.DietaryTags,
                Duration = homeChefMeal.Duration,   
                AvailabilityStatus  = homeChefMeal.AvailabilityStatus,
                FoodCategory = homeChefMeal.FoodCategory,
                PieceSize=homeChefMeal.PieceSize,
                Images = homeChefMeal.HomeChefMealImages.Select(image => image.Image).ToList() ?? new List<string>()

            };
        }
    }
}
