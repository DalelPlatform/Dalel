using Models.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels
{
    public static class ReviewPropertiesExt
    {
        public static ReviewProperties ToModel(this ReviewPropertiesDetailsVM viewModel)
        {
            return new ReviewProperties
            {
                // add properties here
            };
        }
        public static ReviewPropertiesDetailsVM ToDetailsViewModel(this ReviewProperties reviewProperties)
        {
            return new ReviewPropertiesDetailsVM
            {
                Id = reviewProperties.Id,
                Comments = reviewProperties.Comments,
                Rating = reviewProperties.Rating,
            };
        }
    }
}
