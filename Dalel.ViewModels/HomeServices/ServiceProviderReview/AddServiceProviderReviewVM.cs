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
        public int Id { get; set; }
        [Required(ErrorMessage = "Request ID is required.")]
        public int RequestId { get; set; }
        [Required(ErrorMessage = "Service Provider ID is required.")]
        public string ServiceProviderId { get; set; }
        [Required(ErrorMessage = "Client Id is required")]
        public string ClientId { get; set; }

        [Required(ErrorMessage = "Rating is required.")]
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int Rating { get; set; }

        public DateTime? ReviewDate { get; set; }
        [Required(ErrorMessage = "Review text is required.")]
        [StringLength(500, ErrorMessage = "Review cannot exceed 500 characters.")]
        public string Review { get; set; }
    }
}
