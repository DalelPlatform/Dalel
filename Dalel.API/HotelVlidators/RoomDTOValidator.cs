using Dalel.ViewModels.Hotel_DTO;
using FluentValidation;

namespace Dalel.API.Vlidators
{

    public class RoomDTOValidator : AbstractValidator<RoomDTO>
    {
        public RoomDTOValidator()
        {
            RuleFor(x => x.Availability).NotEmpty();
            RuleFor(x => x.RoomTypeId).GreaterThan(0);
        }
    }
}
