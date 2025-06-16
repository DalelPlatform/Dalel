using Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels
{
    public class AddServiceProviderProposalVM
    {
        public string? ServiceProviderId { get; set; }

        [Required(ErrorMessage = "Service request ID is required.")]
        public int ServiceRequestId { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Suggested price is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Suggested price must be greater than zero.")]
        public double SuggestedPrice { get; set; }
        public DateTime? Date { get; set; }

        public string? ServiceProviderName;

        public ProposalStatus Status { get; set; } = ProposalStatus.Pending;
    }
}
