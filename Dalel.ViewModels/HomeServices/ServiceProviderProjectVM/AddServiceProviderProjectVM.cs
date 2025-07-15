using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dalel.ViewModels
{
    public class AddServiceProviderProjectVM
    {
        [Required(ErrorMessage = "Project name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Approximate price is required.")]
        public decimal ApproximatePrice { get; set; }

        [Required(ErrorMessage = "Price unit is required.")]
        public string PriceUnit { get; set; }

        public string ServiceProviderId { get; set; }
        [Required(ErrorMessage = "Image Is Required")]
        public IFormFile? Image { get; set; }
        public string? Imagepath { get; set; } = "";

    }
}