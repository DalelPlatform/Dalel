using Dalel.ViewModels.Hotel_DTO;
using FluentValidation;

namespace Dalel.Validations.Hotel
{
    public class BookingHotelRoomDTOValidator : AbstractValidator<BookingHotelRoomDTO>
    {
        public BookingHotelRoomDTOValidator()
        {
            RuleFor(x => x.Checkin)
                .NotEmpty().WithMessage("Check-in date is required")
                .GreaterThan(DateTime.Now.Date).WithMessage("Check-in date must be in the future");

            RuleFor(x => x.Checkout)
                .NotEmpty().WithMessage("Check-out date is required")
                .GreaterThan(x => x.Checkin).WithMessage("Check-out date must be after check-in");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be positive");

            RuleFor(x => x.NumberOfGuests)
                .InclusiveBetween(1, 10).WithMessage("Number of guests must be between 1 and 10");

            RuleFor(x => x.BookingStatus)
                .NotEmpty().WithMessage("Booking status is required")
                .IsInEnum().WithMessage("Invalid booking status");

            RuleFor(x => x.ClientId)
                .NotEmpty().WithMessage("Client ID is required");

            RuleFor(x => x.RoomId)
                .GreaterThan(0).WithMessage("Invalid room ID");

            RuleFor(x => x.PaymentHotelRoom)
                .SetValidator(new PaymentHotelRoomDTOValidator())
                .When(x => x.PaymentHotelRoom != null);

            RuleFor(x => x.ReviewHotelRoom)
                .SetValidator(new ReviewHotelRoomDTOValidator())
                .When(x => x.ReviewHotelRoom != null);
        }
    }
}