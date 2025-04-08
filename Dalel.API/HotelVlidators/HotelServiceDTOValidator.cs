using Dalel.ViewModels.Hotel_DTO;
using FluentValidation;

namespace Dalel.Validations.Hotel
{
    public class HotelServiceDTOValidator : AbstractValidator<HotelServiceDTO>
    {
        public HotelServiceDTOValidator()
        {
            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0).WithMessage("Price cannot be negative");

            RuleFor(x => x.HotelId)
                .GreaterThan(0).WithMessage("Invalid hotel ID");

            RuleFor(x => x.ServiceId)
                .GreaterThan(0).WithMessage("Invalid service ID");
        }
    }
}