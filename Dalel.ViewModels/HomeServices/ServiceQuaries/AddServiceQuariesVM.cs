using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels
{
    public class AddServiceQuariesVM
    {
        [Required]
        public string ServiceProviderId { get; set; }

        [Required]
        public string ClientId { get; set; }

        [Required]
        [StringLength(1000)]
        public string Question { get; set; }

        [Required]
        public int CategoryServicesId { get; set; }
    }
}
