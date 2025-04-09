using Dalel.ViewModels.Hotel_DTO;
using FluentValidation;

namespace Dalel.Validations.Hotel
{
    public class RoomDTOValidator : AbstractValidator<RoomDTO>
    {
        public RoomDTOValidator()
        {
            RuleFor(x => x.Availability)
                .NotEmpty().WithMessage("Availability status is required")
                .IsInEnum().WithMessage("Invalid availability status");

            RuleFor(x => x.RoomTypeId)
                .GreaterThan(0).WithMessage("Invalid room type ID");
        }
    }
}