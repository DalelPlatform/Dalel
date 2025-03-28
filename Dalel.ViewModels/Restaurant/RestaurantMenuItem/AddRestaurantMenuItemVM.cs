using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Models.Enums;

namespace Dalel.ViewModels
{
    public class AddRestaurantMenuItemVM
    {


        [Required(ErrorMessage = "Please Provide valid Restaurant Name")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Item name must contain at least 3 letter and max 100 letter")]
        public string Name { get; set; }


        [Required(ErrorMessage = "Please Provide valid Description")]
        [StringLength(200, MinimumLength = 20, ErrorMessage = "Description  must contain at least 20 letter and max 200 letter")]
        public string Description { get; set; }


        [Required(ErrorMessage = "Please Provide valid Price")]
        public float Price { get; set; }

        [Required(ErrorMessage = "Please Provide valid Dietary Tag")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Dietary Tag must contain at least 3 letter and max 100 letter")]
        public string DietaryTags { get; set; }


        public FoodCategory FoodCategory { get; set; } //viewDate drop list

        public SizeOfPiece PieceSize { get; set; }

        public double? Duration { get; set; }
        public int RestaurantId { get; set; }

        //    [Required(ErrorMessage = "Please Provide valid Techer email")]
        //    [StringLength(100, MinimumLength = 3, ErrorMessage = "Product name must contain at least 3 letter and max 100 letter")]
        //    public string Email { get; set; }

        //    [Required(ErrorMessage = "Please Provide valid Techer phone")]
        //    [StringLength(15, MinimumLength = 10, ErrorMessage = "Product name must contain at least 3 letter and max 100 letter")]
        //    public string Phone { get; set; }

        public List<string> Paths { get; set; } = new List<string>();
        public IFormFileCollection RestaurantMenuItemImages { get; set; }
    }
}

