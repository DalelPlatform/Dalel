using Dalel.ViewModels;
using Microsoft.IdentityModel.Tokens;
using Models.HomeChef;

namespace Dalel.ViewModels
{
    public static class HomeChefOrderMealExt
    {
        public static HomeChefOrderMeal ToModel(this AddHomeChefOrderMealVM addHomeChefOrderMealVM)
        {
            return new HomeChefOrderMeal
            {
                SupPrice = addHomeChefOrderMealVM.SupPrice,
                Quantity = addHomeChefOrderMealVM.Quantity,
                HomeChefOrdersId = addHomeChefOrderMealVM.HomeChefOrdersId,
                HomeChefMealsId = addHomeChefOrderMealVM.HomeChefMealsId
            };
        }

        public static HomeChefOrderMealDetailsVM ToDetailsViewModel(this HomeChefOrderMeal homeChefOrderMeal)
        {
            return new HomeChefOrderMealDetailsVM
            {
                SupPrice = homeChefOrderMeal.SupPrice,
                Quantity = homeChefOrderMeal.Quantity
            };
        }


        public static HomeChefOrderMeal ToEditModel(this AddHomeChefOrderMealVM addVM, HomeChefOrderMeal old)
        {
            old.SupPrice = addVM.SupPrice > 0
                ? addVM.SupPrice
                : old.SupPrice;

            old.Quantity = addVM.Quantity > 0
                ? addVM.Quantity
                : old.Quantity;

            old.HomeChefOrdersId = addVM.HomeChefOrdersId > 0
                ? addVM.HomeChefOrdersId
                : old.HomeChefOrdersId;

            old.HomeChefMealsId = addVM.HomeChefMealsId > 0
                ? addVM.HomeChefMealsId
                : old.HomeChefMealsId;

            return old;
        }


    }
}
