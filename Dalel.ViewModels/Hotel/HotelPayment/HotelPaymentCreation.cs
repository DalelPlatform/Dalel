using Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels
{
    public class PaymentHotelRoomCreation
    {
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        public float Amount { get; set; }

        [Required]
        [Range(0.00, double.MaxValue, ErrorMessage = "AmountPaid must be non-negative.")]
        public decimal AmountPaid { get; set; }

        [Range(0.00, double.MaxValue, ErrorMessage = "CommissionDeducted must be non-negative.")]
        public decimal? CommissionDeducted { get; set; }

        [StringLength(50, ErrorMessage = "CodeApplied cannot exceed 50 characters.")]
        public string? CodeApplied { get; set; }

        [Required]
        [EnumDataType(typeof(PaymentMethod), ErrorMessage = "Invalid payment method.")]
        public PaymentMethod PaymentMethod { get; set; }

        [Required]
        [EnumDataType(typeof(PaymentStatus), ErrorMessage = "Invalid payment status.")]
        public PaymentStatus PaymentStatus { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime TransactionDateTime { get; set; }

        [Required]
        public int BookingHotelRoomId { get; set; }

        [Required]
        public int ClientId { get; set; }

        [Required]
        public int HotelId { get; set; }
    }
}
