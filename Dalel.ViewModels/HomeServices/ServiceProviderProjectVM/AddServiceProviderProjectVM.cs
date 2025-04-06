using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dalel.ViewModels
{
    public class AddServiceProviderProjectVM
    {
        [Required(ErrorMessage = "Please Provide valid Project Name")]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(1000)]
        [Required(ErrorMessage = "Please Provide valid Description")]
        public string Description { get; set; }

        public List<string> Paths { get; set; } = new List<string>();
        public IFormFileCollection ProjectImages { get; set; }
    }
}