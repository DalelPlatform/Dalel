using Dalel.ViewModels.Hotel_DTO;
using FluentValidation;

namespace Dalel.API.Vlidators
{
    public class RoomTypeImageDTOValidator : AbstractValidator<RoomTypeImageDTO>
    {
        public RoomTypeImageDTOValidator()
        {
            RuleFor(x => x.Image).NotEmpty();
            RuleFor(x => x.RoomTypeId).GreaterThan(0);
        }
    }
}
