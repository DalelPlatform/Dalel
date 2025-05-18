using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dalel.ViewModels;
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


        public static HomeChefMeal ToEditModel(this AddHomeChefMealVM addVM, HomeChefMeal old)
        {
            old.DishName = string.IsNullOrWhiteSpace(addVM.DishName) ? old.DishName : addVM.DishName;
            old.Description = string.IsNullOrWhiteSpace(addVM.Description) ? old.Description : addVM.Description;
            old.Price = addVM.Price > 0 ? addVM.Price : old.Price;

            // No validation needed for bool
            old.AvailabilityStatus = addVM.AvailabilityStatus;
            old.DietaryTags = string.IsNullOrWhiteSpace(addVM.DietaryTags) ? old.DietaryTags : addVM.DietaryTags;

            // Enum validation (avoid assigning default value 0 if it's invalid)
            old.FoodCategory = addVM.FoodCategory != default ? addVM.FoodCategory : old.FoodCategory;
            old.PieceSize = addVM.PieceSize != default ? addVM.PieceSize : old.PieceSize;

            old.Duration = addVM.Duration > 0 ? addVM.Duration : old.Duration;

            return old;
        }


    }
}
