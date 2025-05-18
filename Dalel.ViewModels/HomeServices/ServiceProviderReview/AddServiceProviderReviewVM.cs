using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels
{
    public class AddServiceProviderReviewVM
    {
        [Required(ErrorMessage = "Request ID is required.")]
        public int RequestId { get; set; }

        [Required(ErrorMessage = "Rating is required.")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int Rating { get; set; }

        [Required(ErrorMessage = "Review text is required.")]
        [StringLength(500, ErrorMessage = "Review cannot exceed 500 characters.")]
        public string Review { get; set; }
    }
}
