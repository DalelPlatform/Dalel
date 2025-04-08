using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels
{
    public class AddServiceProviderProposalVM
    {

        [Required(ErrorMessage = "Please Provide valid Price")]
        [Range(0, double.MaxValue)]
        public double SuggestedPrice { get; set; }

        [StringLength(500)]
        [Required(ErrorMessage = "Please Provide valid Description")]
        public string Description { get; set; }
    }
}
