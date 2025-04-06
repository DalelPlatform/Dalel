using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels.HomeServices.ServiceRequest
{
    public class AddServiceRequestVM
    {
        
        //[Required(ErrorMessage = "Please Provide valid Client Name")]
        //[StringLength(255)]
        // public string ClientName { get; set; }
        [Required]
        public string ClientId { get; set; }

        [Required]

        public double StartPrice { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [StringLength(255)]
        public string Address { get; set; }

        public string Image { get; set; }
    }
}
