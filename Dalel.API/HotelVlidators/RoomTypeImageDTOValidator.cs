using Dalel.ViewModels.Hotel_DTO;
using FluentValidation;

namespace Dalel.Validations.Hotel
{
    public class RoomTypeImageDTOValidator : AbstractValidator<RoomTypeImageDTO>
    {
        public RoomTypeImageDTOValidator()
        {
            RuleFor(x => x.Image)
                .NotEmpty().WithMessage("Image URL is required")
                .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _))
                .WithMessage("Image must be a valid URL");

            RuleFor(x => x.RoomTypeId)
                .GreaterThan(0).WithMessage("Invalid room type ID");
        }
    }
}