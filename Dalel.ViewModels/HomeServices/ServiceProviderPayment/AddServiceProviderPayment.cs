using Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Dalel.ViewModels
{
    public class AddServiceProviderPayment
    {
        [Required(ErrorMessage = "Request ID is required.")]
        public int RequestId { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        public double Amount { get; set; }

        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Pending;
    }

}
