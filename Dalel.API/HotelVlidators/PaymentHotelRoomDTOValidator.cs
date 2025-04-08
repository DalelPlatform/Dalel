using Dalel.ViewModels.Hotel_DTO;
using FluentValidation;

namespace Dalel.API.Vlidators
{

    public class PaymentHotelRoomDTOValidator : AbstractValidator<PaymentHotelRoomDTO>
    {
        public PaymentHotelRoomDTOValidator()
        {
            RuleFor(x => x.Amount).GreaterThanOrEqualTo(0);
            RuleFor(x => x.AmountPaid).GreaterThanOrEqualTo(0);
            RuleFor(x => x.PaymentMethod).NotEmpty();
            RuleFor(x => x.PaymentStatus).NotEmpty();
            RuleFor(x => x.TransactionDateTime).NotEmpty();
        }
    }
}
