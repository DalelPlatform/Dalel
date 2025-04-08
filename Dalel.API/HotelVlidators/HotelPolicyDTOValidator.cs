using Dalel.ViewModels.Hotel_DTO;
using FluentValidation;

namespace Dalel.Validations.Hotel
{
    public class HotelPolicyDTOValidator : AbstractValidator<HotelPolicyDTO>
    {
        public HotelPolicyDTOValidator()
        {
            RuleFor(x => x.HotelId)
                .GreaterThan(0).WithMessage("Invalid hotel ID");

            RuleFor(x => x.PolicyName)
                .NotEmpty().WithMessage("Policy name is required")
                .MaximumLength(100).WithMessage("Policy name cannot exceed 100 characters");
        }
    }
}