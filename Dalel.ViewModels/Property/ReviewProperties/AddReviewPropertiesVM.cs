using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels
{
    public class AddReviewPropertiesVM
    {
        [Required(ErrorMessage = "Comments are required.")]
        [StringLength(500, MinimumLength = 5, ErrorMessage = "Comments must be between 5 and 500 characters.")]
        public string Comments { get; set; }

        [Required(ErrorMessage = "Rating is required.")]
        [Range(0.0, 5.0, ErrorMessage = "Rating must be between 0 and 5.")]
        public float Rating { get; set; }

        [Required(ErrorMessage = "Review modification date is required.")]
        public DateTime ModificationDateTime { get; set; }

        [Required(ErrorMessage = "BookingPropertyId is required.")]
        public int BookingPropertyId { get; set; }
    }

}
