using Dalel.ViewModels.Hotel_DTO;
using FluentValidation;

namespace Dalel.Validations.Hotel
{
    public class PaymentHotelRoomDTOValidator : AbstractValidator<PaymentHotelRoomDTO>
    {
        public PaymentHotelRoomDTOValidator()
        {
            RuleFor(x => x.Amount)
                .GreaterThan(0).WithMessage("Amount must be positive");

            RuleFor(x => x.AmountPaid)
                .GreaterThanOrEqualTo(0).WithMessage("Amount paid cannot be negative");

            RuleFor(x => x.PaymentMethod)
                .NotEmpty().WithMessage("Payment method is required")
                .IsInEnum().WithMessage("Invalid payment method");

            RuleFor(x => x.PaymentStatus)
                .NotEmpty().WithMessage("Payment status is required")
                .IsInEnum().WithMessage("Invalid payment status");

            RuleFor(x => x.TransactionDateTime)
                .NotEmpty().WithMessage("Transaction date is required")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Transaction date cannot be in the future");
        }
    }
}