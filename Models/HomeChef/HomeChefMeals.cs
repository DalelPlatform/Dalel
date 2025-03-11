using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.HomeChef.Enums;

namespace Models.HomeChef
{
    public class HomeChefMeals
    {
        public int Id { get; set; }
        public int ChefId { get; set; }

        public string DishName { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string AvailabilityStatus { get; set; }
        public string DietaryTags { get; set; }

        public CategoryOfFood FoodCategory { get; set; }

        public SizeOfPiece PieceSize { get; set; }

        public double Duration { get; set; }
    }
}
