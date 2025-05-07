using Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels
{
    public class AddServiceRequestVM
    {
        [Required(ErrorMessage = "Client ID is required.")]
        public string ClientId { get; set; }

        [Required(ErrorMessage = "Category ID is required.")]
        public int CategoryServicesId { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;
        public RequestStatus Status { get; set; } = RequestStatus.Pending;
    }
}

