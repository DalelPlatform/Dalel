using Dalel.ViewModels.Hotel_DTO;
using FluentValidation;

namespace Dalel.Validations.Hotel
{
    public class BookingGuestInRoomDTOValidator : AbstractValidator<BookingGuestInRoomDTO>
    {
        public BookingGuestInRoomDTOValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Full name is required")
                .MaximumLength(100).WithMessage("Full name cannot exceed 100 characters");

            RuleFor(x => x.NationalID)
                .NotEmpty().WithMessage("National ID is required")
                .Length(10, 20).WithMessage("National ID must be between 10 and 20 characters");

            RuleFor(x => x.NationalIDImage)
                .NotEmpty().WithMessage("National ID image is required")
                .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _))
                .When(x => !string.IsNullOrEmpty(x.NationalIDImage))
                .WithMessage("National ID image must be a valid URL");

            RuleFor(x => x.BookingHotelRoomId)
                .GreaterThan(0).WithMessage("Invalid booking reference");

            RuleFor(x => x.BookingId)
                .GreaterThan(0).WithMessage("Invalid booking ID");
        }
    }
}