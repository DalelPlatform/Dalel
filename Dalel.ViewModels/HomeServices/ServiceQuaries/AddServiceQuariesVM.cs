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
        

        [Required(ErrorMessage = "Category ID is required.")]
        public int CategoryServicesId { get; set; }

        [Required(ErrorMessage = "Question is required.")]
        [StringLength(500, ErrorMessage = "Question cannot exceed 500 characters.")]
        public string Comment { get; set; }
        public DateTime? CommentDate { get; set; } = DateTime.Now;

        public bool IsSenderClient { get; set; }
        public int ChatId { get; set; }
        public string ClientId { get; set; }
        public string ServiceProviderId { get; set; }
    }
}
