using Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalel.ViewModels
{
    public class RoomCreation
    {
        [Required]
        public int RoomTypeId { get; set; }

        [Required]
        [StringLength(50)]
        public string ViewType { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        [Required]
        public AvaliabilityStatus Availability { get; set; }
    }
}


