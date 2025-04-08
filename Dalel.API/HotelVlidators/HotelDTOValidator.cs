using Dalel.API.Vlidators;
using Dalel.ViewModels.Hotel_DTO;
using FluentValidation;

namespace Dalel.Validations.Hotel
{
    public class HotelDTOValidator : AbstractValidator<HotelDTO>
    {
        public HotelDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Hotel name is required")
                .MaximumLength(100).WithMessage("Name cannot exceed 100 characters");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters");

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("City is required")
                .MaximumLength(50).WithMessage("City name cannot exceed 50 characters");

            RuleFor(x => x.Latitude)
                .InclusiveBetween(-90, 90).WithMessage("Invalid latitude value");

            RuleFor(x => x.Longitude)
                .InclusiveBetween(-180, 180).WithMessage("Invalid longitude value");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required")
                .Matches(@"^\+?[0-9\s\-\(\)]{10,20}$")
                .WithMessage("Invalid phone number format");

            RuleFor(x => x.CancelationCharges)
                .GreaterThanOrEqualTo(0).WithMessage("Cancellation charges cannot be negative");

            RuleFor(x => x.VerificationStatus)
                .NotEmpty().WithMessage("Verification status is required");

            RuleForEach(x => x.HotelImages)
                .SetValidator(new HotelImageDTOValidator());

            RuleForEach(x => x.RoomTypes)
                .SetValidator(new RoomTypeDTOValidator());
        }
    }
}