using System.ComponentModel.DataAnnotations;

namespace Dalel.ViewModels
{
    public class ForgotPasswordVM
    {
        [Required, EmailAddress]
        public string Email { get; set; }
    }
}