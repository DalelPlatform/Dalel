using Dalel.ViewModels.Hotel_DTO;
using FluentValidation;
using Dalel.Core.Contracts; // Assuming repository interfaces are in Core

namespace Dalel.API.Validators
{
    public class BookingGuestInRoomDTOValidator : AbstractValidator<BookingGuestInRoomDTO>
    {
       

        public BookingGuestInRoomDTOValidator()
        {
            

            // Use regions to organize validation rules
            #region Basic Information Validation
            RuleFor(x => x.FullName)
                .NotEmpty()
                .WithMessage("Guest name is required")
                .MaximumLength(100)
                .WithMessage("Name cannot exceed 100 characters")
                .Matches(@"^[\p{L} \.'\-]+$")
                .WithMessage("Name contains invalid characters");

            RuleFor(x => x.NationalID)
                .NotEmpty()
                .WithMessage("National ID is required")
                .Length(10, 20)
                .WithMessage("National ID must be between 10-20 characters")
                .Matches(@"^\d+$")
                .WithMessage("National ID must contain only numbers");
            #endregion

            #region Document Validation
            RuleFor(x => x.NationalIDImage)
                .NotEmpty()
                .WithMessage("ID image is required")
                .Must(BeAValidImagePath)
                .WithMessage("Invalid image file format")
                .When(x => !string.IsNullOrEmpty(x.NationalIDImage));
            #endregion

           
        }

        // Custom validation method for image path
        private bool BeAValidImagePath(string path)
        {
            if (string.IsNullOrWhiteSpace(path)) return false;

            var validExtensions = new[] { ".jpg", ".jpeg", ".png", ".pdf" };
            return validExtensions.Contains(Path.GetExtension(path).ToLower());
        }
    }
}