using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dalel.ViewModels;
using Models;
using Models.Enums;
using Models.HomeChef;

namespace Dalel.Repository
{
    public class HomeChefMealRepository : BaseRepository<HomeChefMeal>
    {
        public HomeChefMealRepository(DelelContext dalelContext) : base(dalelContext) 
        {

        }


        public HomeChefMealDetailsVM GetMealById(int id)
        {

            return base.GetList(meal => meal.Id == id).Select(m => new HomeChefMealDetailsVM()).FirstOrDefault();

        }

        public List<HomeChefMealDetailsVM> GetAllMeals()
        {
            return base.GetList().Select(m => new HomeChefMealDetailsVM()
            {
                DishName = m.DishName,
                Description = m.Description,
                DietaryTags = m.DietaryTags,
                Duration = m.Duration,
                AvailabilityStatus = m.AvailabilityStatus,
                FoodCategory = m.FoodCategory,
                PieceSize = m.PieceSize,
                Price = m.Price,
                Images = m.HomeChefMealImages.Select(image =>  image.Image).ToList()


            }).ToList();
        }

     

        public List<HomeChefMealDetailsVM> GetMealsByChefId (string chefId)
        {
            return base.GetList(meals => meals.HomeChefId == chefId)
                .Select(m => new HomeChefMealDetailsVM()).ToList() ;
        }

        public List<HomeChefMealDetailsVM> GetMealsByCategory(FoodCategory category)
        {
            return base.GetList(meals => meals.FoodCategory == category)
                .Select(m => new HomeChefMealDetailsVM()).ToList();
        }

        public List<HomeChefMealDetailsVM> SearchMeals(string keyword)
        {
            return base.GetList(meals => meals.DishName.Contains(keyword) || meals.Description.Contains(keyword))
                .Select(m => new HomeChefMealDetailsVM()).ToList();
        }

        public List<HomeChefMealDetailsVM> GetAvailableMeals(bool status)
        {
            return base.GetList(meals => meals.AvailabilityStatus == status)
                .Select(m => new HomeChefMealDetailsVM()).ToList();
        }

    }
}
