using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels.HomeServices.ServiceProviderReview
{
    public class AddServiceProviderReviewVM
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Provide a Review")]
        [StringLength(1000)]
        public string Review { get; set; }

        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }
    }
}
