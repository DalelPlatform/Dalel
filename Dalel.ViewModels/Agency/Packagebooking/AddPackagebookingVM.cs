using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Enums;

namespace Dalel.ViewModels.Agency.Packagebooking
{
    public class AddPackagebookingVM
    {
        [Required(ErrorMessage = "Please Provide valid BookingStatus")]
        public BookingStatus BookingStatus { get; set; }
        [Required(ErrorMessage = "Please Provide valid Date")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Please Provide valid ReservedPeople")]
        public int ReservedPeople { get; set; }
        [Required(ErrorMessage = "Please Provide valid TotalPrice")]
        public float TotalPrice { get; set; }
    }
}
