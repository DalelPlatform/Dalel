using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels.Agency.PackageStep
{
    public class addPackageStepVM
    {
        [Required(ErrorMessage = "Please Provide Name")]
 
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Provide Description")]
        public string Description { get; set; }
       
        public float? Duration { get; set; }

        public string? Image { get; set; }
        public IFormFile? ImageFile { get; set; }
        public int PackageId { get; set; }

    }
}
