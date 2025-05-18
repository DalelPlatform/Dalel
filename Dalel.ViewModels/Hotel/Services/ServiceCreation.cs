using System.ComponentModel.DataAnnotations;

namespace Dalel.ViewModels
{
    public class ServiceCreation
    {
        [Required(ErrorMessage = "Service name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(255, ErrorMessage = "Description cannot exceed 255 characters.")]
        public string Description { get; set; }

        public bool IsActive { get; set; } = true; // Default to true
    }
}
