using Dalel.ViewModels.HomeChef.HomeChefOrderMeal;
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
    }
}
