using Dalel.ViewModels.Hotel_DTO;
using FluentValidation;

namespace Dalel.Validations.Hotel
{
    public class HotelImageDTOValidator : AbstractValidator<HotelImageDTO>
    {
        public HotelImageDTOValidator()
        {
            RuleFor(x => x.Image)
                .NotEmpty().WithMessage("Image URL is required")
                .Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _))
                .WithMessage("Image must be a valid URL")
                .Must(url => url.EndsWith(".jpg") || url.EndsWith(".png") || url.EndsWith(".jpeg"))
                .WithMessage("Image must be JPG, PNG, or JPEG format");

            RuleFor(x => x.HotelId)
                .GreaterThan(0).WithMessage("Invalid hotel ID");
        }
    }
}