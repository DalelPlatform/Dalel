using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Enums;

namespace Dalel.ViewModels
{
    public class HomeChefMealDetailsVM
    {

        public string DishName { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public bool AvailabilityStatus { get; set; }
        public string DietaryTags { get; set; }
        public FoodCategory FoodCategory { get; set; }
        public SizeOfPiece PieceSize { get; set; }
        public double? Duration { get; set; }
        public List<string> Images { get; set; }
    }
}
