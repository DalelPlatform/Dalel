using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dalel.ViewModels.Agency.Packagebooking;
using Models.Agency;

namespace Dalel.ViewModels.Agency.PackageSchadule
{
    public class addPackageSchaduleVM
    {
        [Required(ErrorMessage = "Please Provide Valid date")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "this field is Required ")]
        public int SlotsAvailable { get; set; }
        public int PackageId { get; set; }
       public List<AddPackagebookingVM> PackageBookings { get; set; }
    }
}
