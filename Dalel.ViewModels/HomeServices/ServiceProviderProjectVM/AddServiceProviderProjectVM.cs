using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dalel.ViewModels
{
    public class AddServiceProviderProjectVM
    {
        [Required(ErrorMessage = "Service provider ID is required.")]
        public string ServiceProviderId { get; set; }

        [Required(ErrorMessage = "Project name is required.")]
        [StringLength(100, ErrorMessage = "Project name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; }

        public IFormFile ImageFile { get; set; }
        public string ImagePath { get; set; }
    }
}