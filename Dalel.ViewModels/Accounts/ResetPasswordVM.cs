using System.ComponentModel.DataAnnotations;

namespace Dalel.ViewModels
{
    public class ResetPasswordVM
    {
        [Required]
        public string Token { get; set; }

        [Required, StringLength(100, MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required, Compare(nameof(NewPassword))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}