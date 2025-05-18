using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels
{
    public class AddServiceQuariesVM
    {
        [Required(ErrorMessage = "Client ID is required.")]
        public string ClientId { get; set; }

        [Required(ErrorMessage = "Category ID is required.")]
        public int CategoryServicesId { get; set; }

        [Required(ErrorMessage = "Question is required.")]
        [StringLength(500, ErrorMessage = "Question cannot exceed 500 characters.")]
        public string Question { get; set; }

        public string ServiceProviderId { get; set; }
    }
}
