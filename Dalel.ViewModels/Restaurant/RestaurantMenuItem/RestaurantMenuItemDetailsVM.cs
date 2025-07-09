using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Enums;


namespace Dalel.ViewModels
{
    public class RestaurantMenuItemDetailsVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public AvaliabilityStatus AvailabilityStatus { get; set; }
        public FoodCategory FoodCategory { get; set; }
        public SizeOfPiece PieceSize { get; set; }
        public string DietaryTags { get; set; }

        
        public double? Duration { get; set; }

        public string RestaurantName { get; set; }

        public RestaurantType? RestaurantType { get; set; }
        

        public List<string> Images {  get; set; }

        
    }
}
